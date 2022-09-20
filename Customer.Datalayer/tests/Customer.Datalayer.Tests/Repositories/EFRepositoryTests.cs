﻿using Customer.Datalayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer.Datalayer.EFRepositories;
using Xunit;

namespace Customer.Datalayer.Tests.Repositories
{
    public class EFRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateEFCustomerRepository()
        {
            var efRepository = new EFCustomerRepository();
            Assert.NotNull(efRepository);
        }

        [Fact]
        public void ShouldBeAbleToCreateEFAddressRepository()
        {
            var efRepository = new EFAddressRepository();
            Assert.NotNull(efRepository);
        }

    }
}