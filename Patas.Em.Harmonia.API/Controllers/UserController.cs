using Microsoft.AspNetCore.Mvc;
using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models;

namespace Patas.Em.Harmonia.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserData user)
        {
            var response = await _userService.CreateUser(user);
            return response ? StatusCode(201) : StatusCode(400);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserByEmailAsync([FromQuery] string email)
        {
            var response = await _userService.GetUserByMail(email);
            return response != null ? Ok(response) : NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletUserByEmailAsync([FromQuery] string email)
        {
            var response = await _userService.DeleteUserByEmail(email);
            return response ? Ok() : NoContent();
        }

        [HttpPatch]
        public async Task<IActionResult> ChangeUserDataAsync([FromBody] UserData user)
        {
            var response = await _userService.ChangeUserData(user);
            return Ok(response);
        }
    }
}