using Microsoft.AspNetCore.Mvc;
using MyTunes.Models;
using MyTunes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTunes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerRepository _customerRepository;

        public CustomersController(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: api/customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            // Going to use our CustomerRepository to fetch all customers
            return Ok(_customerRepository.GetAllCustomers());
        }

        // GET api/customers/ALFKI
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(string id)
        {
            // Going to use our CustomerRepository to fetch a specific customer
            return Ok(_customerRepository.GetCustomer(id));
        }

        // POST api/customers
        [HttpPost]
        public ActionResult Post(Customer customer)
        {
            // Going to use our CustomerRepository to add a new customer 
            bool success = _customerRepository.AddNewCustomer(customer);
            return CreatedAtAction(nameof(Get), new { id = customer.CustomerId}, success);
        }

        // PUT api/customers/ALFKI
        [HttpPut("{id}")]
        public ActionResult Put(int id, Customer customer)
        {
            // Check for bad request 
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }
            // Going to use our CustomerRepository to update an existing customer 
            bool success = _customerRepository.UpdateCustomer(customer);
            return NoContent();
        }
    }

}

