using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Interfaces;
using Customer.Datalayer.Mvc.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Customer.Datalayer.Mvc.Tests.Controllers
{
    [TestClass]
    public class AddressesControllerTests
    {
        [TestMethod]
        public void ShouldBeAbleToCreateAddressesController()
        {
            var controller = new AddressesController();
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void ShouldBeAbleToReturnAllAddresses()
        {
            var address = new AddressesController();
            var addressesIndex = address.Index(1);
            var addressesView = addressesIndex as ViewResult;
            var addressesModel = addressesView.Model as PagedList<Addresses>;
            int? addressesNumber = addressesModel.Count();
            Assert.IsTrue(addressesNumber != null);
        }

        [TestMethod]
        public void ShouldBeAbleToCreateAction()
        {
            // test for redirect
            var addressesController = new AddressesController();

            var result = addressesController.Create(new Addresses()
            {
                CustomerID = 9,
                AddressLine = "test",
                AddressLine2= "test2",
                AddressType = "Shipping",
                City= "TestCity",
                PostalCode = "12341",
                StateName = "TestState",
                Country = "USA"
            }) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldBeAbleToCreateAddress()
        {
            var addressServiceMock = new Mock<IService<Addresses>>();
            var addressesController = new AddressesController(addressServiceMock.Object);
            addressesController.Create();
            var address = new Addresses()
            {
                CustomerID = 9,
                AddressLine = "test",
                AddressLine2 = "test2",
                AddressType = "Shipping",
                City = "TestCity",
                PostalCode = "12341",
                StateName = "TestState",
                Country = "USA"
            };
            addressesController.Create(address);

            addressServiceMock.Verify(x => x.Create(address));
        }

        [TestMethod]
        public void ShouldBeAbleToEditAddress()
        {
            var addressServiceMock = new Mock<IService<Addresses>>();
            var addressesController = new AddressesController(addressServiceMock.Object);

            var address = new Addresses()
            {
                CustomerID = 9,
                AddressLine = "test",
                AddressLine2 = "test2",
                AddressType = "Shipping",
                City = "TestCity",
                PostalCode = "12341",
                StateName = "TestState",
                Country = "USA"
            };
            addressesController.Edit(2);

            var result = addressesController.Edit(5, address) as RedirectToRouteResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldBeAbleToDeleteAddress()
        {
            var addressServiceMock = new Mock<IService<Addresses>>();
            var addressesController = new AddressesController(addressServiceMock.Object);

            addressesController.Delete(1);
            var result = addressesController.DeleteConfirmed(5) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            addressServiceMock.Verify(x => x.Delete(5));
        }

        [TestMethod]
        public void ShouldBeAbleToShowDetails()
        {
            var addressesController = new AddressesController();
            var address = (addressesController.Details(3) as ViewResult).Model as Addresses;

            Assert.AreEqual("line", address.AddressLine);
        }
    }
}
