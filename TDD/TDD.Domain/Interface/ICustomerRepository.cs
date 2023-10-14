using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Domain.Model;

namespace TDD.Domain.Interface
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        int AddCustomer(Customer customer);
        public int UpdateCustomer(Customer updatedCustomer);
        public int RemoveCustomer(Customer deleteCustomer);
        public Customer GetById(int id);
    }
}
