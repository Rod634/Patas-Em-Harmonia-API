using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models.DTO;
using Patas.Em.Harmonia.Domain.Models.Entities;

namespace Patas.Em.Harmonia.Services
{
    public class VaccineService : IVaccineService
    {
        private readonly IVaccineRepository _vaccineRepository;

        public VaccineService(IVaccineRepository vaccineRepository)
        {
            _vaccineRepository = vaccineRepository;
        }

        public Task<List<NameIdDto>> GetAllVaccines()
        {
            return _vaccineRepository.GetAllVaccines();
        }

        public Task<bool> CreateVaccineAnimall(VaccineDto vaccineDto, string animalId)
        {
            var vaccineAnimal = (VaccineAnimal)vaccineDto;
            vaccineAnimal.IdAnimal = animalId;
            return _vaccineRepository.AddAnimalVaccine(vaccineAnimal);
        }

        public Task<bool> ChangeVaccineAnimall(ChangeVaccineDto vaccineDto)
        {
            return _vaccineRepository.ChangeAnimalVaccine(vaccineDto);
        }
    }
}
