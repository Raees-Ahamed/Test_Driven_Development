using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Core.Context;
using TDD.Domain.Interface;
using TDD.Domain.Model;

namespace TDD.Core.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public int AddCustomer(Customer customer)
        {
            _context.customers.Add(customer);
            return _context.SaveChanges();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.customers.OrderByDescending(d => d.Name).ToList();
        }

        public int UpdateCustomer(Customer updatedCustomer)
        {
            _context.customers.Update(updatedCustomer);
            return _context.SaveChanges();
        }

        public int RemoveCustomer(Customer deleteCustomer)
        {
            _context.customers.Remove(deleteCustomer);
            return _context.SaveChanges();
        }

        public Customer GetById(int id)
        {
            return _context.customers.Find(id);
        }
    }
}
