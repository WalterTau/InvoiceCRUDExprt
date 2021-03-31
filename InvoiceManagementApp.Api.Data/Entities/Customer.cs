using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagementApp.Api.Data
{
   public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string EmailAddress { get; set; }
    }
}
