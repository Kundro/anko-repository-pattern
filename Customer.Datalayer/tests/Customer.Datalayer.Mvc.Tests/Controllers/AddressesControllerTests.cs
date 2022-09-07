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
        public void ShouldNotBeAbleToEditCustomer()
        {
            var addressServiceMock = new Mock<IService<Addresses>>();
            var addressesController = new AddressesController(addressServiceMock.Object);
            const int addressId = 0;
            var result = addressesController.Edit(addressId) as HttpNotFoundResult;

            Assert.AreEqual(new HttpNotFoundResult().StatusCode, result.StatusCode);
        }

        [TestMethod]
        public void ShouldNotBeAbleToEditConfirmedCustomer()
        {
            var addressServiceMock = new Mock<IService<Addresses>>();
            var addressesController = new AddressesController(addressServiceMock.Object);
            const int addressId = 0;
            var result = addressesController.Edit(addressId, null) as HttpStatusCodeResult;

            Assert.AreEqual(new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest).StatusCode, result.StatusCode);
        }

        [TestMethod]
        public void ShouldBeAbleToDeleteAddress()
        {
            var addressServiceMock = new Mock<IService<Addresses>>();
            addressServiceMock.Setup(x => x.Read(6)).Returns(new Addresses() { AddressID = 6 });
            addressServiceMock.Setup(x => x.Delete(6));
            var addressesController = new AddressesController(addressServiceMock.Object);

            if ((addressesController.Delete(1) as ViewResult)?.Model is Addresses result) Assert.AreEqual(6, result.AddressID);
        }

        [TestMethod]
        public void ShouldBeAbleToDeleteConfirmedAddress()
        {
            var addressServiceMock = new Mock<IService<Addresses>>();
            var addressesController = new AddressesController(addressServiceMock.Object);

            addressesController.Delete(1);
            var result = addressesController.DeleteConfirmed(1) as RedirectToRouteResult;

            addressServiceMock.Verify(x => x.Delete(1));
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void ShouldNotBeAbleToDeleteConfirmedCustomer()
        {
            var addressServiceMock = new Mock<IService<Addresses>>();
            var addressesController = new AddressesController(addressServiceMock.Object);
            const int addressId = 0;
            var result = addressesController.DeleteConfirmed(addressId) as HttpStatusCodeResult;

            Assert.AreEqual(new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest).StatusCode, result.StatusCode);
        }

        [TestMethod]
        public void ShouldNotBeAbleToDeleteCustomer()
        {
            var addressServiceMock = new Mock<IService<Addresses>>();
            var addressesController = new AddressesController(addressServiceMock.Object);
            const int addressId = 0;
            var result = addressesController.Delete(addressId) as HttpNotFoundResult;

            Assert.AreEqual(new HttpNotFoundResult().StatusCode, result.StatusCode);
        }

        [TestMethod]
        public void ShouldBeAbleToShowDetails()
        {
            var addressesController = new AddressesController();
            var address = (addressesController.Details(4) as ViewResult).Model as Addresses;

            Assert.AreEqual("line", address.AddressLine);
        }

        [TestMethod]
        public void ShouldNotBeAbleToShowDetails()
        {
            var addressServiceMock = new Mock<IService<Addresses>>();
            var addressesController = new AddressesController(addressServiceMock.Object);
            const int addressId = 0;
            var result = addressesController.Details(addressId) as HttpStatusCodeResult;

            Assert.AreEqual(new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest).StatusCode, result.StatusCode);
        }
    }
}
