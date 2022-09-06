using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Customer.Datalayer.Business;
using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Interfaces;
using PagedList;

namespace Customer.Datalayer.Mvc.Controllers
{
    public class AddressesController : Controller
    {
        private readonly IService<Addresses> _addressService;

        public AddressesController()
        {
            _addressService = new AddressService();
        }

        public AddressesController(IService<Addresses> addressService)
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
                return RedirectToAction("Details", "Customers", new { id = address.CustomerID});
            }
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int id)
        {
            var address = _addressService.Read(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Addresses/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Addresses address)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Error. Invalid customer fields. Try again.";
                return View(address);
            }
            else
            {   
                _addressService.Update(address);
                return RedirectToAction("Details", "Customers", new { id = address.CustomerID });
            }
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int id)
        {
            var address = _addressService.Read(id);
            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var addresses = _addressService.Get();
            var customerId = addresses[addresses.Count - 1].CustomerID;
            _addressService.Delete(id);
            return RedirectToAction("Details", "Customers", new { id = customerId });
        }
    }
}
