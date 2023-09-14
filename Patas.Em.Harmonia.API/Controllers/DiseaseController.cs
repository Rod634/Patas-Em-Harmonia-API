using Microsoft.AspNetCore.Mvc;
using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models.DTO;

namespace Patas.Em.Harmonia.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class DiseaseController : ControllerBase
    {
        private readonly IDiseaseService _diseaseService;

        public DiseaseController(IDiseaseService diseaseService)
        {
            _diseaseService = diseaseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDiseaseNamesAsync()
        {
            var response = await _diseaseService.GetAllDiseaseNames();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddDiseaseToAnAnimalAsync([FromBody] DiseaseDto disease, string animalId)
        {
            var response = await _diseaseService.CreateDiseaseAnimall(disease, animalId);
            return response ? Ok() : NoContent();
        }

        [HttpPatch]
        public async Task<IActionResult> ChangeVaccineAnimalAsync([FromBody] ChangeDiseaseDto diseaseDto)
        {
            var response = await _diseaseService.ChangeDiseaseAnimall(diseaseDto);
            return response ? Ok() : NoContent();
        }
    }
}