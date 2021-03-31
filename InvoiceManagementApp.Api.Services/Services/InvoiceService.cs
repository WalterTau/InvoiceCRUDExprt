using InvoiceManagementApp.Api.Data;
using InvoiceManagementApp.Api.Interface.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Api.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly InvoiceManagementDBContext _dbcontext;
        private readonly IExportService _exportService;

        public InvoiceService(InvoiceManagementDBContext dbcontext , IExportService exportService)
        {
            _dbcontext = dbcontext;
            this._exportService = exportService;
        }

        public Invoice Add(Invoice model)
        {
            try
            {

                _dbcontext.Invoice.Add(model);
                _dbcontext.SaveChanges();
                _dbcontext.Dispose();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(string.Format("{0}-{1}", "Error ", ex.InnerException));
            }
            return model;
        }

        public async Task<Invoice> Get(int Id)
        {
            var invoice = await _dbcontext.Invoice.FindAsync(Id);
            await _exportService.ExportToExcelOrCSV(invoice);
            return invoice;
        }

        public async Task<IEnumerable<Invoice>> GetInvoices()
        {
            var result = new List<Invoice>();
            try
            {
                result = await _dbcontext.Set<Invoice>().ToListAsync();
                await _exportService.ExportAllInvoicesToCSVOrExcel(result);


            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("{0}-{1}", "Error ", ex.InnerException));
            }

            return result;
        }

        public async Task<int> Update(int Id, Invoice model)
        {
            var invoice = _dbcontext.Customer.FindAsync(Id);
            try
            {
                if (invoice != null)
                {
                    _dbcontext.Entry(invoice).CurrentValues.SetValues(model);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("{0}-{1}", "Error ", ex.InnerException));
            }

            return await Task.Run(() =>
            {
                _dbcontext.Update(invoice);
                return _dbcontext.SaveChanges();
            });
        }
    }
}
