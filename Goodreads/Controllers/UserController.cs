using Goodreads.Helpers.Attributes;
using Goodreads.Models.DTOs;
using Goodreads.Models.Enum;
using Goodreads.Models;
using Goodreads.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Goodreads.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser(UserRequestDTO user)
        {
            var userToCreate = new User
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Role = Role.User,
                Email = user.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password)
            };

            await _userService.Create(userToCreate);
            return Ok();
        }

        [HttpPost("createAdmin")]
        public async Task<IActionResult> CreateAdmin(UserRequestDTO user)
        {
            var userToCreate = new User
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Role = Role.Admin,
                Email = user.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password)
            };

            await _userService.Create(userToCreate);
            return Ok();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UserRequestDTO user)
        {
            var response = _userService.Authenticate(user);
            if (response == null)
            {
                return BadRequest("Invalid username or password!");
            }
            return Ok();
        }

        [HttpGet("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpPut("update/{id}")]
        [Authorization(Role.Admin, Role.User)]
        public IActionResult UpdateUser(Guid id, [FromBody] UserRequestDTO user)
        {
            var userToUpdate = _userService.GetById(id);
            if (userToUpdate == null)
            {
                return BadRequest("The user ID was not found!");
            }
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;
            _userService.Save();
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        [Authorization(Role.Admin)]
        public IActionResult DeleteUser(Guid id)
        {
            var userToDelete = _userService.GetById(id);
            if (userToDelete == null)
            {
                return BadRequest("The user ID was not found!");
            }
            _userService.Delete(userToDelete);
            _userService.Save();
            return Ok();
        }
    }
}
