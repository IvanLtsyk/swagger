using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Data.Models;
using WebApiCore.Data.Services;

namespace WebApiCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        /// <summary>
        ///    Get All Customers.
        /// </summary>
        /// <remarks>
        /// Sample request: 
        /// 
        /// GET: api/Customers
        /// 
        /// </remarks>
        /// <returns> A list of existing custoers</returns>
        /// <response code = "200"> Success</response>
        /// <response code = "400"> If error occurs</response>
        /// <response code = "404"> If no customers in database</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IList<Customer>>> GetCustomers()
        {
            return Ok(await _customerService.GetAllAsync());
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerService.FindByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> PutCustomer(int id, Customer customer)
        {
            var oldEntity = _customerService.FindByIdAsync(id);
            if (id != customer.Id || oldEntity == null)
            {
                return BadRequest();
            }

            return Ok(await _customerService.UpdateAsync(customer));
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            return Ok(await _customerService.AddAsync(customer));
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _customerService.FindByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            await _customerService.DeleteAsync(customer);


            return NoContent();
        }
    }
}
