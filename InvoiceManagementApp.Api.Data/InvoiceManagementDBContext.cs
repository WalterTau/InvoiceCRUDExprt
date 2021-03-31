using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagementApp.Api.Data
{
    public class InvoiceManagementDBContext : DbContext
    {
        public InvoiceManagementDBContext(DbContextOptions options) 
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }

      
    }
}
