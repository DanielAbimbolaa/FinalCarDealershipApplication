using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FinalCarDealershipApplication.Interfaces;
using FinalCarDealershipApplication.Models;
using FinalCarDealershipApplication.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using FinalCarDealershipApplication.Repository;
using Microsoft.EntityFrameworkCore;


namespace FinalCarDealershipApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {
        private readonly ICarsRepository _CarsRepository;
        private readonly IMapper _mapper;

        public CarsController(ICarsRepository CarsRepository, IMapper mapper)
        {
            _CarsRepository = CarsRepository;
             _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Cars>))]
        public IActionResult GetCars()
        {

            var Cars = _mapper.Map<List<CarDto>>(_CarsRepository.GetCars());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Cars);
        }

        [HttpGet("carID")]
        [ProducesResponseType(200, Type = typeof(Cars))]
        [ProducesResponseType(400)]
        public IActionResult GetCars(string carID)
        {
            if (!_CarsRepository.CarsExists(carID))
                return NotFound();

            var car = _mapper.Map<CarDto>(_CarsRepository.GetCars(carID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(car);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateCar([FromBody] CarDto carCreate)
        {
            if (carCreate == null)
                return BadRequest(ModelState);

            var car = _CarsRepository.GetCars()
                .Where(c => c.carID == carCreate.carID)
                .FirstOrDefault();

            if (car != null)
            {
                ModelState.AddModelError("", "Car already exists");
                return StatusCode(422, ModelState);
            }

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var carMap = _mapper.Map<Cars>(carCreate);

            if(_CarsRepository.CreateCar(carMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("carID")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCar(string carID,
            [FromBody] CarDto updatedCar)
        {

            if (updatedCar == null)
                return BadRequest(ModelState);

            if (carID != updatedCar.carID)
                return BadRequest(ModelState);

            if (!_CarsRepository.CarsExists(carID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var carMap = _mapper.Map<Cars>(updatedCar);

            if (!_CarsRepository.UpdateCar(carMap))
            {
                ModelState.AddModelError("", "Something went wrong updating car");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("carId")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCar(string carID)
        {
            if (!_CarsRepository.CarsExists(carID))
            {
                return NotFound();
            }

            var carToDelete = _CarsRepository.GetCars(carID);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_CarsRepository.DeleteCar(carToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting admin");
            }

            return NoContent();
        }



    }
}