using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FinalCarDealershipApplication.Interfaces;
using FinalCarDealershipApplication.Models;
using FinalCarDealershipApplication.Dto;
using PokemonReviewApp.Repository;


namespace FinalCarDealershipApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _CustomerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository CustomerRepository, IMapper mapper)
        {
            _CustomerRepository = CustomerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customers>))]
        public IActionResult GetCustomers()
        {
            //Get the Customers
            var customerList = _CustomerRepository.GetCustomers();
            //Map gthe Customer
            var Customers = _mapper.Map<List<CustomerDto>>(customerList);
            //Return customers
            return Ok(Customers);
        }

        [HttpGet("customerID")]
        [ProducesResponseType(200, Type = typeof(Customers))]
        [ProducesResponseType(400)]
        public IActionResult GetCars(string customerID)
        {
            if (!_CustomerRepository.CustomerExists(customerID))
                return NotFound();

            var customer = _mapper.Map<CustomerDto>(_CustomerRepository.GetCustomerById(customerID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(customer);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateCustomer([FromBody] CustomerDto customerCreate)
        {
            if (customerCreate == null)
                return BadRequest(ModelState);

            var customer = _CustomerRepository.GetCustomers()
                .Where(c => c.customerId == customerCreate.customerId)
                .FirstOrDefault();

            if (customer != null)
            {
                ModelState.AddModelError("", "Customer already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerMap = _mapper.Map<Customers>(customerCreate);
            var addCustomer = !_CustomerRepository.CreateCustomers(customerMap);
            if (addCustomer)
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpDelete("customerId")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCustomer(string customerID)
        {
            if (!_CustomerRepository.CustomerExists(customerID))
            {
                return NotFound();
            }

            var customerToDelete = _CustomerRepository.GetCustomerById(customerID);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_CustomerRepository.DeleteCustomer(customerToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting admin");
            }

            return NoContent();
        }



    }
}