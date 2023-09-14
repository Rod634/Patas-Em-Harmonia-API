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
        private readonly IValidator<CreateAnimalDto> _validator;

        public AnimalService(IAnimalRepository animalRepository, IVaccineRepository vaccineRepository, IDiseaseRepository diseaseRepository,  IValidator<CreateAnimalDto> validator)
        {
            _animalRepository = animalRepository;
            _vaccineRepository = vaccineRepository;
            _diseaseRepository = diseaseRepository;
            _validator = validator;
        }

        public async Task<bool> UpdateAnimal(UpdateAnimalDto animal)
        {
            if (string.IsNullOrEmpty(animal.IdAnimal))
            {
                throw new ArgumentException(Constant.STATUS_ID_EMPTY_WARNING);
            }

            var isSuccess = await _animalRepository.UpdateAnAnimal(animal);
            return isSuccess;
        }

        public async Task<bool> CreateAnimal(CreateAnimalDto animalRequest)
        {
            try
            {
                _validator.ValidateAndThrow(animalRequest);

                var animal = (Animal)animalRequest;
                var Id = Guid.NewGuid().ToString();

                var isSuccess = await _animalRepository.CreateAnimal(animal);

                if (isSuccess)
                {
                    await BindAnimalToDisease(animalRequest.Disease, Id);
                    await BindAnimalToVaccine(animalRequest.Vaccine, Id);
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

        private async Task<bool> BindAnimalToDisease(List<DiseaseDto> diseaseDto, string id)
        {
            foreach (DiseaseDto disease in diseaseDto)
            {
                var d = (DiseaseAnimal)disease;
                d.IdAnimal = id;
                await _diseaseRepository.AddAnimalDisease(d);
            }
            
            return true;
        }

        private async Task<bool> BindAnimalToVaccine(List<VaccineDto> vaccineDto, string id)
        {
            foreach(VaccineDto vaccine in vaccineDto)
            {
                var v = (VaccineAnimal)vaccine;
                v.IdAnimal = id;
                await _vaccineRepository.AddAnimalVaccine(v);
            }
            return true;
        }
    }
}
