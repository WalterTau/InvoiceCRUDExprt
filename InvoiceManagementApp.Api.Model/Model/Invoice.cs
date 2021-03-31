using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace InvoiceManagementApp.Api.Model
{
    public class InvoiceHeader
    {
       
        public string NameOfClient { get; set; }
        public int Invoice_No { get; set; }
        public int Quantity { get; set; }
        public string SKU_Number{ get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public InvoicePaymentStatus Payment_Status { get; set; }
        public int Customer_No { get; set; }
        public decimal Price { get; set; }
        public decimal Vat { get; set; }
      
        public decimal Total_Amount_InclusiveVAT { get; set; }
    }
}
