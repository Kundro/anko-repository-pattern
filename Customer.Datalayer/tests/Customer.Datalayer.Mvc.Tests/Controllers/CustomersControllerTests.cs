using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Interfaces;
using Customer.Datalayer.Mvc.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Xml.Linq;
using Customer.Datalayer.Repositories;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

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
            var customersIndex = controller.Index();
            var customersView = customersIndex as ViewResult;
            var customersModel = customersView.Model as List<Customers>;

            Assert.IsTrue(customersModel != null && customersModel.Exists(x=>x.CustomerID > 0));
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
            var customers = (customersController.Index() as ViewResult).Model as List<Customers>;
            Assert.IsTrue(customers.Exists(x => x.FirstName == "NewFirstName"));
        }

        [TestMethod]
        public void ShouldNotBeAbleToCreateCustomer()
        {
            var mockCustomerRepository = new Mock<CustomerRepository>();
            var customersController = new CustomersController(mockCustomerRepository.Object);

            var result = customersController.Create(new Customers()
            {
                FirstName = "testName1",
                LastName = "testSurname1",
                PhoneNumber = "+123123456780",
                Email = "mail@mail.ru",
                Notes = "note1",
                TotalPurchasesAmount = 1
            }) as RedirectToRouteResult;
            Assert.IsNull(result);
        }
    }
}
