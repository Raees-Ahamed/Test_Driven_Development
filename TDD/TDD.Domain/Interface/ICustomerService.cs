using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Domain.Model;

namespace TDD.Domain.Interface
{
    public interface ICustomerService
    {
        public IEnumerable<Customer> GetCustomers();
        public int AddCustomer(Customer customer);
        public int UpdateCustomer(Customer customer);
        public int RemoveCustomer(Customer customer);
        public Customer GetById(int id);
    }
}
