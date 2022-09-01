using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Interfaces;
using Customer.Datalayer.Mvc.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;
using Customer.Datalayer.Repositories;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using PagedList;

namespace Customer.Datalayer.Mvc.Tests.Controllers
{
    [TestClass]
    public class CustomersControllerTests
    {
        [TestMethod]
        public void ShouldBeAbleToCreateCustomersController()
        {
            var controller = new CustomersController();
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void ShouldBeAbleToReturnAllCustomers()
        {
            var controller = new CustomersController();
            var customersIndex = controller.Index(1);
            var customersView = customersIndex as ViewResult;
            var customersModel = customersView.Model as PagedList<Customers>;
            int? customersNumber = customersModel.Count();
            Assert.IsTrue(customersNumber != null);
        }
          
        [TestMethod]
        public void ShouldBeAbleToCreateAction()
        {
            // test for redirect
            var mockCustomerRepository = new Mock<CustomerRepository>();
            var customersController = new CustomersController(mockCustomerRepository.Object);

            var result = customersController.Create(new Customers()
            {
                FirstName = "testName2",
                LastName = "testSurname1",
                PhoneNumber = "+12341234567890",
                Email = "mail@mail.ru",
                Notes = "note1",
                TotalPurchasesAmount = 1
            }) as RedirectToRouteResult;

            Assert.IsNotNull(result); 
        }

        [TestMethod]
        public void ShouldBeAbleToCreateCustomer()
        {
            var customersController = new CustomersController();
            var customer = new Customers()
            {
                FirstName = "NewFirstName",
                LastName = "testSurname1",
                PhoneNumber = "+12341234567890",
                Email = "mail@mail.ru",
                Notes = "note1",
                TotalPurchasesAmount = 1
            };
            customersController.Create(customer);
            var customers = (customersController.Index(4) as ViewResult).Model as PagedList<Customers>;
            // Assert.IsTrue(customers.);
        }
    }
}
