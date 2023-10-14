using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Core.Services;
using TDD.Domain.Interface;
using TDD.Domain.Model;

namespace TDD.Test
{
    [TestClass]
    public class CustomerTests
    {
        private readonly Mock<ICustomerRepository> mockCustomerRepository;
        public CustomerTests()
        {
            mockCustomerRepository = new Mock<ICustomerRepository>();
        }

        [TestMethod]
        public void GetCustomersSuccess()
        {
            //Arrange            
            mockCustomerRepository.Setup(m => m.GetCustomers()).Returns(
                new List<Customer>{
                  new Customer {
                    Id = 1,
                    Name = "Samman",
                    Address = "Colombo"
                  },
                  new Customer {
                    Id = 2,
                    Name = "Roshan",
                    Address = "Colombo"
                  }});

            CustomerService customer = new CustomerService(mockCustomerRepository.Object);

            //Act
            var customers = customer.GetCustomers();

            //Assert
            Assert.IsNotNull(customers);
        }

        [TestMethod]
        public void AddCustomersSuccess()
        {
            //Arrange
            mockCustomerRepository.Setup(m => m.AddCustomer(new Customer
            {
                Id = 2,
                Name = "Samman",
                Address = "Colombo"
            })).Returns(1);

            CustomerService customer = new CustomerService(mockCustomerRepository.Object);

            //Act
            var results = customer.AddCustomer(new Customer
            {
                Id = 2,
                Name = "Samman",
                Address = "Colombo"
            });

            //Assert
            Assert.IsNotNull(results);

        }

        [TestMethod]
        public void UpdateCustomerSuccess()
        {
            //Arrange
            mockCustomerRepository.Setup(x => x.GetById(2)).Returns(new Customer
            {
                Id = 2,
                Name = "Samman",
                Address = "Colombo"
            });

            CustomerService customer = new CustomerService(mockCustomerRepository.Object);

            //Act
            var results = customer.UpdateCustomer(new Customer
            {
                Id = 2,
                Name = "kjjkj",
                Address = "kjjk"
            });

            //Assert
            Assert.IsNotNull(results);
        }

        [TestMethod]
        public void DeleteCustomerSuccess()
        {
            //Arrange
            mockCustomerRepository.Setup(x => x.RemoveCustomer(new Customer
            {
                Id = 2,
                Name = "Samman",
                Address = "Colombo"
            })).Returns(1);

            CustomerService customer = new CustomerService(mockCustomerRepository.Object);

            //Act
            var deleteCustomer = customer.RemoveCustomer(new Customer
            {
                Id = 2,
                Name = "Samman",
                Address = "Colombo"
            });

            //Assert
            Assert.IsNotNull(deleteCustomer);
        }
    }
}
