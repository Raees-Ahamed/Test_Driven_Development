using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TDD.Domain.Interface;
using TDD.Domain.Model;

namespace TDD.Api.Controllers.v1
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        [Route("GetCustomer")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            return Ok(customerService.GetCustomers());
        }

        [HttpPost]
        [Route("CreateCustomer")]
        public ActionResult CreateCustomer([FromBody] Customer customer)
        {
            customerService.AddCustomer(customer);
            return Ok("Customer created successfully");
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        public ActionResult UpdateCustomer([FromBody] Customer customer)
        {
            var updateCustomer = customerService.UpdateCustomer(customer);
            return Ok("Customer updated successfully");
        }

        [HttpDelete]
        [Route("DeleteCustomer")]
        public ActionResult DeleteCustomer([FromBody] Customer customer)
        {
            customerService.RemoveCustomer(customer);
            return Ok("customer deleted successfully");
        }
    }
}

