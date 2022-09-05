using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Customer.Datalayer.Business;
using Customer.Datalayer.BusinessEntities;
using PagedList;

namespace Customer.Datalayer.Mvc.Controllers
{
    public class AddressesController : Controller
    {
        private readonly AddressService _addressService;

        public AddressesController()
        {
            _addressService = new AddressService();
        }

        public AddressesController(AddressService addressService)
        {
            _addressService = addressService;
        }
        //GET: Addresses
        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 5;
            var customers = _addressService.Get();
            return View(customers.ToPagedList(pageNumber, pageSize));
        }

        // GET: Addresses/Details/5
        public ActionResult Details(int id)
        {
            var address = _addressService.Read(id);
            return View(address);
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Addresses/Create
        [HttpPost]
        public ActionResult Create(Addresses address)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Error. Invalid address fields. Try again.";
                return View();
            } else {
                _addressService.Create(address);
                var addresses = _addressService.Get();
                var customerId = addresses[addresses.Count - 1].CustomerID;
                return RedirectToAction("Details", "Customers", new { id = customerId });
            }
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int id)
        {
            var address = _addressService.Read(id);
            return View(address);
        }

        // POST: Addresses/Edit/5
        [HttpPost]
        public ActionResult Edit(Addresses address)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Error. Invalid customer fields. Try again.";
                return View(address);
            }
            else
            {   
                var addresses = _addressService.Get();
                var customerId = addresses[addresses.Count-1].CustomerID;
                _addressService.Update(address);
                return RedirectToAction("Details", "Customers", new { id = customerId });
            }
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Addresses/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
