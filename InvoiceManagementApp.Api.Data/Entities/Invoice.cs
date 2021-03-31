using InvoiceManagementApp.Api.Model.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvoiceManagementApp.Api.Data
{
   public  class Invoice
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string SkuId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public InvoicePaymentStatus Status { get; set; }
        public int CustId { get; set; }
        public decimal Price { get; set; }
        public decimal Vat { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal TotalAmount { get; set; }

    }
}
