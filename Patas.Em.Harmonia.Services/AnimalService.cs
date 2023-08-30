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
        private readonly IValidator<AnimalDto> _validator;

        public AnimalService(IAnimalRepository animalRepository, IValidator<AnimalDto> validator)
        {
            _animalRepository = animalRepository;
            _validator = validator;
        }

        public async Task<bool> ChangeAnimalStatus(string status, int animalId)
        {
            if (string.IsNullOrEmpty(status) || animalId < 0)
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
                var isSuccess = await _animalRepository.CreateAnimal(animal);
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

        public async Task<List<Animal>> GetAnimalsFromAUser(int userId)
        {
            if (userId < 0)
            {
                throw new ArgumentException(Constant.STATUS_ID_EMPTY_WARNING);
            }

            var animals = await _animalRepository.GetAllAnimalsFromAnUser(userId);
            return animals;
        }
    }
}
