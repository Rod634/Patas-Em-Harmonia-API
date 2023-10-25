using Microsoft.AspNetCore.Mvc;
using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models.DTO;

namespace Patas.Em.Harmonia.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AccessController : ControllerBase
    {
        private readonly IAccessService _accessService;

        public AccessController(IAccessService accessService)
        {
            _accessService = accessService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> GetUserByEmailAsync([FromBody] LoginDto login)
        {
            var response = await _accessService.UserLogin(login);
            return response.Id != null ? Ok(response) : NoContent();
        }
    }
}