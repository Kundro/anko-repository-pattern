using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Interfaces;
using Customer.Datalayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Customer.Datalayer.Business;
using Microsoft.Ajax.Utilities;
using PagedList;

namespace Customer.Datalayer.Mvc.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerService _customerService;

        public CustomersController()
        {
            _customerService = new CustomerService();
        }

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: Customers
        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 7;
            var customers = _customerService.GetCustomers();
            return View(customers.ToPagedList(pageNumber, pageSize));
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            var allAddresses = _customerService.GetAllAddresses();
            ViewBag.AllAddresses = allAddresses;
            var customer = _customerService.ReadCustomer(id);

            // check if no addresses in customer
            var check = true;
            int customerID = _customerService.ReadCustomer(id).CustomerID;
            if (!allAddresses.Exists(x => x.CustomerID == customerID))
            {
                check = false;
            }
            ViewBag.Check = check;

            if (customer==null) return View("Error");
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
           return View();
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(Customers customer)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Error. Invalid customer fields. Try again.";
                return View();
            } else {
                _customerService.CreateCustomer(customer);
                return RedirectToAction("Index");
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _customerService.ReadCustomer(id);
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(Customers customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.UpdateCustomer(customer);
                return RedirectToAction("Index");
            }
            else
            {
                return View(customer);
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _customerService.ReadCustomer(id);
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _customerService.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}
