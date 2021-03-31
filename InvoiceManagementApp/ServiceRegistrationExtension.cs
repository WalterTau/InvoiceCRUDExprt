using InvoiceManagementApp.Api.Interface.Services;
using InvoiceManagementApp.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementApp
{
    public static class ServiceRegistrationExtension
    {
        public static void RegisterService(this IServiceCollection services) 
        {
            services.AddTransient<IInvoiceService, InvoiceService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IExportService, ExportService>();
        }
    }
}
