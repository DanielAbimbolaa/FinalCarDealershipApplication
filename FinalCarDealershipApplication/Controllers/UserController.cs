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
    public class UserController : Controller
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository UserRepository, IMapper mapper)
        {
            _UserRepository = UserRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUser()
        {
            var User = _mapper.Map<List<UserDto>>(_UserRepository.GetUser());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(User);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateUser([FromBody] UserDto userCreate)
        {
            if (userCreate == null)
                return BadRequest(ModelState);

            var user = _UserRepository.GetUser()
                .Where(c => c.userId == userCreate.userId)
                .FirstOrDefault();

            if (user != null)
            {
                ModelState.AddModelError("", "User already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userMap = _mapper.Map<User>(userCreate);

            if (!_UserRepository.CreateUser(userMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpDelete("userId")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(string userID)
        {
            if (!_UserRepository.UserExists(userID))
            {
                return NotFound();
            }

            var userToDelete = _UserRepository.GetUserById(userID);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_UserRepository.DeleteUser(userToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting admin");
            }

            return NoContent();
        }



    }
}