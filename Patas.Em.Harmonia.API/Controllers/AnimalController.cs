using Microsoft.AspNetCore.Mvc;
using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models.DTO;

namespace Patas.Em.Harmonia.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnimalAsync([FromBody] AnimalDto animal)
        {
            var response = await _animalService.CreateAnimal(animal);
            return response ? StatusCode(201) : StatusCode(400);
        }

        [HttpPost("change-status")]
        public async Task<IActionResult> ChangeAnimalStatusAsync(string status, int animalId)
        {
            var response = await _animalService.ChangeAnimalStatus(status, animalId);
            return response ? Ok() : NoContent();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAnimalsAsync()
        {
            var response = await _animalService.GetAllAnimals();
            return Ok(response);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetAllAnimalsByUserAsync([FromQuery] int userId)
        {
            var response = await _animalService.GetAnimalsFromAUser(userId);
            return Ok(response);
        }

    }
}