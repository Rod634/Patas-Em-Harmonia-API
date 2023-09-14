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
        public async Task<IActionResult> CreateAnimalAsync([FromBody] CreateAnimalDto animal)
        {
            var response = await _animalService.CreateAnimal(animal);
            return response ? StatusCode(201) : StatusCode(400);
        }

        [HttpPost("change")]
        public async Task<IActionResult> ChangeAnimalDataAsync(UpdateAnimalDto animal)
        {
            var response = await _animalService.UpdateAnimal(animal);
            return response ? Ok() : NoContent();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAnimalsAsync()
        {
            var response = await _animalService.GetAllAnimals();
            return Ok(response);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetAllAnimalsByUserAsync([FromQuery] string userId, string ngoId)
        {
            var response = await _animalService.GetAnimalsFromAUser(userId, ngoId);
            return Ok(response);
        }

    }
}