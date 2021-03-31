using CsvHelper;
using InvoiceManagementApp.Api.Data;
using InvoiceManagementApp.Api.Interface.Services;
using ViewModel = InvoiceManagementApp.Api.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Api.Services
{
    public class ExportService : IExportService
    {
        private readonly InvoiceManagementDBContext _dbcontext;

        public ExportService(InvoiceManagementDBContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        public async Task<IEnumerable<Invoice>> ExportAllInvoicesToCSVOrExcel(List<Invoice> model)
        {
            try
            {



                DateTime dateInvoice = DateTime.Now;
                var invoiceDownloadedName = dateInvoice.ToString("yyyyMMdd_HHmmss");
                using (var memomryStream = new MemoryStream())
                using (var streamWriter = new StreamWriter(@"C:\Users\Administrator\Documents\Invoices\" + invoiceDownloadedName + ".csv"))
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {

                    csvWriter.WriteHeader<ViewModel.InvoiceHeader>();
                    csvWriter.NextRecord();



                    // get customer name 
                    // var custome
                    if (model != null)
                    {
                        foreach (var invoice in model)
                        {
                            //Get Customer name 
                            var customerInfo = await _dbcontext.Customer.FindAsync(invoice.CustId);
                            csvWriter.WriteField(customerInfo.Name);
                            csvWriter.WriteRecord<Invoice>(invoice);
                            csvWriter.NextRecord();


                        }
                        await csvWriter.FlushAsync();
                        StreamReader dataReader = new StreamReader(memomryStream, Encoding.UTF8, true);



                    }

                }

            }
            catch (CsvHelperException ex)
            {
                Console.WriteLine(string.Format("{0}-{1}", "Error ", ex.InnerException));
            }
            return model;
        }

        public async Task<Invoice> ExportToExcelOrCSV(Invoice model)
        {
            try
            {



                DateTime dateInvoice = DateTime.Now;
                var invoiceDownloadedName = dateInvoice.ToString("yyyyMMdd_HHmmss");
                using (var memomryStream = new MemoryStream())
                using (var streamWriter = new StreamWriter(@"C:\Users\Administrator\Documents\Invoices\" + invoiceDownloadedName + ".csv"))
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {

                    csvWriter.WriteHeader<ViewModel.InvoiceHeader>();
                    csvWriter.NextRecord();



                    // get customer name 
                    // var custome
                    if (model != null)
                    {
                       
                            //Get Customer name 
                            var customerInfo = await _dbcontext.Customer.FindAsync(model.CustId);
                            csvWriter.WriteField(customerInfo.Name);
                            csvWriter.WriteRecord<Invoice>(model);
                            csvWriter.NextRecord();

                            await csvWriter.FlushAsync();
                            StreamReader dataReader = new StreamReader(memomryStream, Encoding.UTF8, true);



                    }

                }

            }
            catch (CsvHelperException ex)
            {
                Console.WriteLine(string.Format("{0}-{1}", "Error ", ex.InnerException));
            }
            return model;
        }
    }
}
