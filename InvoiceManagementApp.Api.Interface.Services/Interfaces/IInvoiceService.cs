using InvoiceManagementApp.Api.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Api.Interface.Services
{
   public interface IInvoiceService
    {
        Task<IEnumerable<Invoice>> GetInvoices();
        Task<int> Update(int Id, Invoice model);
        Invoice Add(Invoice model);
        Task<Invoice> Get(int Id);
        Invoice Delete(int Id);

    }
}
