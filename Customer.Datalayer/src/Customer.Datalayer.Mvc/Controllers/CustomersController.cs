using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Interfaces;
using Customer.Datalayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var customer = _customerService.ReadCustomer(id);
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
            try
            {
                _customerService.CreateCustomer(customer);
                return RedirectToAction("Index");
            } 
            catch
            {
                return View("Error");
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
