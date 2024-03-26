using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FinalCarDealershipApplication.Interfaces;
using FinalCarDealershipApplication.Models;
using FinalCarDealershipApplication.Dto;


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

        [HttpGet("{Make}")]
        [ProducesResponseType(200, Type = typeof(Cars))]
        [ProducesResponseType(400)]
        public IActionResult GetCars(string Make)
        {
            if (!_CarsRepository.CarsExixts(Make))
                return NotFound();

            var Cars = _mapper.Map<CarDto>(_CarsRepository.GetCars(Make));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Cars);
        }

        [HttpGet("{Year")]
        [ProducesResponseType(200, Type = typeof(Cars))]
        [ProducesResponseType(400)]
        public IActionResult GetCars(int Year)
        {
            if (!_CarsRepository.CarsExixts(Year))
                return NotFound();

            var Cars = _mapper.Map<CarDto>(_CarsRepository.GetCars(Year));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Cars);
        }


    }
}