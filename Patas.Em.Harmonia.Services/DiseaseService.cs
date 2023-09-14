using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models.DTO;
using Patas.Em.Harmonia.Domain.Models.Entities;

namespace Patas.Em.Harmonia.Services
{
    public class DiseaseService : IDiseaseService
    {
        private readonly IDiseaseRepository _diseaseRepository;

        public DiseaseService(IDiseaseRepository diseaseRepository)
        {
            _diseaseRepository = diseaseRepository;
        }

        public Task<List<NameIdDto>> GetAllDiseaseNames()
        {
            return _diseaseRepository.GetAllDiseaseNames();
        }

        public Task<bool> CreateDiseaseAnimall(DiseaseDto disease, string animalId)
        {
            var diseaseAnimal = (DiseaseAnimal)disease;
            diseaseAnimal.IdAnimal = animalId;
            return _diseaseRepository.AddAnimalDisease(diseaseAnimal);
        }

        public Task<bool> ChangeDiseaseAnimall(ChangeDiseaseDto diseaseDto)
        {
            return _diseaseRepository.ChangeAnimalDisease(diseaseDto);
        }
    }
}
