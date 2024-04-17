using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FinalCarDealershipApplication.Interfaces;
using FinalCarDealershipApplication.Models;
using FinalCarDealershipApplication.Dto;
using PokemonReviewApp.Repository;
using FinalCarDealershipApplication.Repository;
using FinalCarDealershipApplication.Data;

namespace FinalCarDealershipApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : Controller
    {
        private readonly ISaleRepository _SaleRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _dbContext;

        public SaleController(DataContext dbContext,ISaleRepository SaleRepository, IMapper mapper)
        {
            _SaleRepository = SaleRepository;
            _mapper = mapper;
            _dbContext=dbContext;
        }

        [HttpGet("Sales")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Sales>))]
        public IActionResult GetSales()
        {
            var Sales = _mapper.Map<List<SaleDto>>(_SaleRepository.GetSales());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Sales);
        }

        [HttpGet("saleID")]
        [ProducesResponseType(200, Type = typeof(Sales))]
        [ProducesResponseType(400)]
        public IActionResult GetSales(string saleID)
        {
            if (!_SaleRepository.SaleExists(saleID))
                return NotFound();

            var sale = _mapper.Map<SaleDto>(_SaleRepository.GetSales(saleID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(sale);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateSales([FromBody] SaleDto saleCreate)
        {
            //if (saleCreate. == null)
            //    return BadRequest(ModelState);

            ////var sale = _SaleRepository.GetSales()
            //    .Where(s => s.saleId == saleCreate.SaleId)
            //    .FirstOrDefault();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //var saleMap = _mapper.Map<Sales>(saleCreate);
            //Validate the car
            var car = _dbContext.Cars.Where(c => c.carID == saleCreate.CarId).FirstOrDefault();      //LINQ Query
            if (car == null)
            {
               return BadRequest("Invalid Car Selected");
            }
            //Validate the customer
            var customer = _dbContext.Customers.Where(c => c.customerId == saleCreate.CustomerId).FirstOrDefault();
            if(customer == null )
            {
                return BadRequest("Invalid Customer Selected");
            }
            //Map the sales DTo to Sales
            var salesMap = new Sales()
            {
                 Cars=car,
                 Customers=customer
            };

            var createSale = _SaleRepository.CreateSales(salesMap);
            if (!createSale)
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpDelete("saleId")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteSale(string saleId)
        {
            if (!_SaleRepository.SaleExists(saleId))
            {
                return NotFound();
            }

            var saleToDelete = _SaleRepository.GetSales(saleId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_SaleRepository.DeleteSale(saleToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting admin");
            }

            return NoContent();
        }

    }
}