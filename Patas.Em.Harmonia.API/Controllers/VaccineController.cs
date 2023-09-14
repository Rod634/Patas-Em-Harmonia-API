using Microsoft.AspNetCore.Mvc;
using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models.DTO;

namespace Patas.Em.Harmonia.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class VaccineController : ControllerBase
    {
        private readonly IVaccineService _vaccineService;

        public VaccineController(IVaccineService vaccineService)
        {
            _vaccineService = vaccineService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVaccinesAsync()
        {
            var response = await _vaccineService.GetAllVaccines();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddVaccineToAnAnimalAsync([FromBody] VaccineDto vaccine, string animalId)
        {
            var response = await _vaccineService.CreateVaccineAnimall(vaccine, animalId);
            return response ? Ok() : NoContent();
        }

        [HttpPatch]
        public async Task<IActionResult> ChangeVaccineAnimalAsync([FromBody] ChangeVaccineDto vaccine)
        {
            var response = await _vaccineService.ChangeVaccineAnimall(vaccine);
            return response ? Ok() : NoContent();
        }

    }
}