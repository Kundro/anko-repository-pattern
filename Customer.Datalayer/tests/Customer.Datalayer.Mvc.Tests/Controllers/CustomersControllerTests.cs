using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Mvc.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
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
            var allCustomers = controller.Index();
            var customersView = allCustomers as ViewResult;
            var customersModel = customersView.Model as List<Customers>;

            Assert.IsTrue(customersModel.Exists(x=>x.TotalPurchasesAmount > 0));
        }
    }
}
