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
    public class AdminController : Controller
    {
        private readonly IAdminRepository _AdminRepository;
        private readonly IMapper _mapper;

        public AdminController(IAdminRepository AdminRepository, IMapper mapper)
        {
            _AdminRepository = AdminRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Admins>))]
        public IActionResult GetAdmin()
        {
            var Admins = _mapper.Map<List<AdminDto>>(_AdminRepository.GetAdmin());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Admins);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateAdmin([FromBody] AdminDto adminCreate)
        {
            if (adminCreate == null)
                return BadRequest(ModelState);

            var admin = _AdminRepository.GetAdmin()
                .Where(a => a.adminId == adminCreate.adminId)
                .FirstOrDefault();

            if (admin != null)
            {
                ModelState.AddModelError("", "Admin already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var adminMap = _mapper.Map<Admins>(adminCreate);

            if (_AdminRepository.CreateAdmins(adminMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpDelete("adminId")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteAdmin(string adminId)
        {
            if(!_AdminRepository.AdminExists(adminId))
            {
                return NotFound();
            }

            var adminToDelete = _AdminRepository.GetAdmin(adminId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_AdminRepository.DeleteAdmin(adminToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting admin");
            }

            return NoContent();
        }
    }
}