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
using Customer.Datalayer.Business;
using Customer.Datalayer.Repositories;
using FluentAssertions.Execution;
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
            var customersIndex = controller.Index(4);
            var customersView = customersIndex as ViewResult;
            var customersModel = customersView.Model as PagedList<Customers>;
            int? customersNumber = customersModel.Count();
            Assert.IsTrue(customersNumber != null);
        }
          
        [TestMethod]
        public void ShouldBeAbleToCreateAction()
        {
            // test for redirect
            var customersController = new CustomersController();

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
            var customerServiceMock = new Mock<IService<Customers>>();
            var customersController = new CustomersController(customerServiceMock.Object);
            customersController.Create();
            var customer = new Customers()
            {
                FirstName = "NewFirstName",
                LastName = "testSurname1",
                PhoneNumber = "+12341234567890",
                Email = "mail@mail.ru",
                Notes = "note1",
                TotalPurchasesAmount = 1
            };
            var result = customersController.Create(customer) as RedirectToRouteResult;
            Assert.IsNotNull(result);

            customerServiceMock.Verify(x => x.Create(customer));
        }

        [TestMethod]
        public void ShouldBeAbleToEditCustomer()
        {
            var customerServiceMock = new Mock<IService<Customers>>();
            var customersController = new CustomersController(customerServiceMock.Object);

            var customer = new Customers()
            {
                FirstName = "NewFirstName",
                LastName = "testSurname1",
                PhoneNumber = "+12341234567890",
                Email = "mail@mail.ru",
                Notes = "note1",
                TotalPurchasesAmount = 1
            };
            customersController.Edit(5);

            var result = customersController.Edit(5, customer) as RedirectToRouteResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var customerServiceMock = new Mock<IService<Customers>>();
            var customersController = new CustomersController(customerServiceMock.Object);

            customersController.Delete(5);
            var result = customersController.DeleteConfirmed(5) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            customerServiceMock.Verify(x => x.Delete(5));
        }

        [TestMethod]
        public void ShouldBeAbleToShowDetails()
        {
            var customersController = new CustomersController();
            var customer = (customersController.Details(7) as ViewResult).Model as Customers;

            Assert.AreEqual("testName2", customer.FirstName);
        }
    }
}
