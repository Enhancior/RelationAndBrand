using ApiToExcel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiToExcel.Services
{
    interface ICustomerService
    {
        Task<CustomerList> GetCustomersAsync(string endpoint);
        IEnumerable<Customer> CompareCustomers();
    }
}
