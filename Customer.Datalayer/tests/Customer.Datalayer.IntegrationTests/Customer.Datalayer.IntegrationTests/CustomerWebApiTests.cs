using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.EFRepositories;
using Customer.Datalayer.Interfaces;
using Customer.Datalayer.WebApi.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using BadRequestResult = Microsoft.AspNetCore.Mvc.BadRequestResult;
using OkResult = Microsoft.AspNetCore.Mvc.OkResult;

namespace Customer.Datalayer.IntegrationTests
{
    public class CustomerWebApiTests
    {
        [Fact]
        public void ShouldCreateCustomerController()
        {
            var customerContextMock = new Mock<CustomerDbContext>();
            var customerController = new CustomerController(customerContextMock.Object);
            customerController.Should().NotBe(null);
        }

        [Fact]
        public void ShouldNotBeAbleToCreateCustomer()
        {
            var customerContextMock = new Mock<CustomerDbContext>();
            var customerController = new CustomerController(customerContextMock.Object);
            Customers? customer = null;
            var response = customerController.AddCustomer(customer);
            response.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
