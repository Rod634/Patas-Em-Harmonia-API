using Microsoft.AspNetCore.Mvc;
using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models;

namespace Patas.Em.Harmonia.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class NgoController : ControllerBase
    {
        private readonly INGOService _nGOService;

        public NgoController(INGOService nGOService)
        {
            _nGOService = nGOService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNgoAsync([FromBody] NgoData ngo)
        {
            var response = await _nGOService.CreateNgo(ngo);
            return response ? StatusCode(201) : StatusCode(400);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNgosAsync()
        {
            var response = await _nGOService.GetAllNgos();
            return Ok(response);
        }
    }
}