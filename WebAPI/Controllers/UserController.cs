using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Service;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private IUserRepository _userRepository;

        public UserController(IUserService userService,IUserRepository userRepository)
        {
            this._userService = userService;
            this._userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] User user)
        {
            try
            {
                User added = await _userRepository.AddUserAsync(user);
                return Created($"/{added.UserName}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<User>> ValidateUser([FromQuery] string username, [FromQuery] string password)
        {
            try
            {
                var user = await _userService.ValidateUser(username, password);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}