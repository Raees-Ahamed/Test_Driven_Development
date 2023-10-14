using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Domain.Interface;
using TDD.Domain.Model;

namespace TDD.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public int AddCustomer(Customer customer)
        {
            var isCustomerAdded = customerRepository.AddCustomer(customer);
            return isCustomerAdded;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var customerList = customerRepository.GetCustomers();
            return customerList;
        }

        public int UpdateCustomer(Customer customer)
        {
            var customerToUpdate = customerRepository.GetById(customer.Id);
            customerToUpdate.Address = customer.Address;
            customerToUpdate.Name = customer.Name;

            var customerUpdateSuccess = customerRepository.UpdateCustomer(customerToUpdate);
            return customerUpdateSuccess;
        }

        public int RemoveCustomer(Customer customer)
        {
            var deleteCustomer = customerRepository.RemoveCustomer(customer);
            return deleteCustomer;
        }

        public Customer GetById(int id)
        {
            return customerRepository.GetById(id);
        }
    }
}
