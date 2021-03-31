
using InvoiceManagementApp.Api.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Api.Interface.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<int> Update(int Id, Customer model);
        Customer Add(Customer model);
        Task<Customer> Get(int Id);
    }
}
