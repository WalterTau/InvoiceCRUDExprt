using InvoiceManagementApp.Api.Data;
using InvoiceManagementApp.Api.Interface.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly InvoiceManagementDBContext _dbcontext;

        public CustomerService(InvoiceManagementDBContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        public Customer Add(Customer model)
        {
            try
            {

                _dbcontext.Customer.Add(model);
                _dbcontext.SaveChanges();
                _dbcontext.Dispose();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(string.Format("{0}-{1}", "Error ", ex.InnerException));
            }
            return model;
        }

        public async Task<Customer> Get(int Id)
        {
            var product = await _dbcontext.Customer.FindAsync(Id);
            return product;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var result = new List<Customer>();
            try
            {
                result = await _dbcontext.Set<Customer>().ToListAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("{0}-{1}", "Error ", ex.InnerException));
            }

            return result;
        }

  
        public async Task<int> Update(int Id, Customer model)
        {
            var customer = _dbcontext.Customer.FindAsync(Id);
            try
            {
                if (customer != null)
                {
                    _dbcontext.Entry(customer).CurrentValues.SetValues(model);
                }

               
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("{0}-{1}", "Error ", ex.InnerException));
            }

            return await Task.Run(() =>
            {
                _dbcontext.Update(customer);
                return _dbcontext.SaveChanges();
            });
        }
    }
}
