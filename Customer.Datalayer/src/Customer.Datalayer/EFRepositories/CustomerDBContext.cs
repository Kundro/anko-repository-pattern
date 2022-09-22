﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer.Datalayer.BusinessEntities;

namespace Customer.Datalayer.EFRepositories
{
    public class CustomerDBContext : DbContext

    {
        public CustomerDBContext()
            : base("Server=.\\SQLEXPRESS;Database=redbull3;Trusted_Connection=True;")
        {
        }

        public IDbSet<Customers> Customers { get; set; } = null;
        public IDbSet<Addresses> Addresses { get; set; } = null;
    }
}
