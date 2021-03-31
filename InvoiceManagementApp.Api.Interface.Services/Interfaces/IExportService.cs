using InvoiceManagementApp.Api.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Api.Interface.Services
{
    public interface IExportService
    {
        Task<Invoice> ExportToExcelOrCSV(Invoice model);
        Task<IEnumerable<Invoice>> ExportAllInvoicesToCSVOrExcel(List<Invoice> model);

    }
}
