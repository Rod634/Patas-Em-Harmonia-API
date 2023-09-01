using FluentValidation;
using Patas.Em.Harmonia.Domain.Constants;
using Patas.Em.Harmonia.Domain.Exceptions;
using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models.DTO;
using Patas.Em.Harmonia.Domain.Models.Entities;

namespace Patas.Em.Harmonia.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IVaccineRepository _vaccineRepository;
        private readonly IDiseaseRepository _diseaseRepository;
        private readonly IValidator<AnimalDto> _validator;

        public AnimalService(IAnimalRepository animalRepository, IVaccineRepository vaccineRepository, IDiseaseRepository diseaseRepository,  IValidator<AnimalDto> validator)
        {
            _animalRepository = animalRepository;
            _vaccineRepository = vaccineRepository;
            _diseaseRepository = diseaseRepository;
            _validator = validator;
        }

        public async Task<bool> ChangeAnimalStatus(string status, string animalId)
        {
            if (string.IsNullOrEmpty(status) || string.IsNullOrEmpty(animalId))
            {
                throw new ArgumentException(Constant.STATUS_ID_EMPTY_WARNING);
            }

            var isSuccess = await _animalRepository.ChangeAnAnimalStatus(status, animalId);
            return isSuccess;
        }

        public async Task<bool> CreateAnimal(AnimalDto animalRequest)
        {
            try
            {
                _validator.ValidateAndThrow(animalRequest);

                var animal = (Animal)animalRequest;
                animalRequest.Disease.IdAnimal = animal.Id;
                animalRequest.Vaccine.IdAnimal = animal.Id;

                var isSuccess = await _animalRepository.CreateAnimal(animal);

                if (isSuccess)
                {
                    await BindAnimalToDisease(animalRequest.Disease);
                    await BindAnimalToVaccine(animalRequest.Vaccine);
                }
                return isSuccess;
            }
            catch (Exception e)
            {
                throw new DomainException(e.Message);
            }
        }

        public async Task<List<Animal>> GetAllAnimals()
        {
            return await _animalRepository.GetAllAnimals();
        }

        public async Task<List<Animal>> GetAnimalsFromAUser(string userId, string ngoId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException(Constant.STATUS_ID_EMPTY_WARNING);
            }

            var animals = await _animalRepository.GetAllAnimalsFromAnUser(userId, ngoId);
            return animals;
        }

        private async Task<bool> BindAnimalToDisease(DiseaseDto diseaseDto)
        {
            var disease = (DiseaseAnimal)diseaseDto;
            return await _diseaseRepository.AddAnimalDisease(disease);
        }

        private async Task<bool> BindAnimalToVaccine(VaccineDto vaccineDto)
        {
            var vaccine = (VaccineAnimal)vaccineDto;
            return await _vaccineRepository.AddAnimalVaccine(vaccine);
        }
    }
}
