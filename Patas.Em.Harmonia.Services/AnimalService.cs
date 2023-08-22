using FluentValidation;
using Patas.Em.Harmonia.Domain.Constants;
using Patas.Em.Harmonia.Domain.Exceptions;
using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models;
using Patas.Em.Harmonia.Domain.Models.Entities;

namespace Patas.Em.Harmonia.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IValidator<UserData> _validator;

        public AnimalService(IAnimalRepository animalRepository, IValidator<UserData> validator)
        {
            _animalRepository = animalRepository;
            _validator = validator;
        }

        public async Task<bool> ChangeAnimalState(string status, int animalId)
        {
            if (string.IsNullOrEmpty(status) || animalId < 0)
            {
                throw new ArgumentException(Constant.STATUS_ID_EMPTY_WARNING);
            }

            var isSuccess = await _animalRepository.ChangeAnAnimalStatus(status, animalId);
            return isSuccess;
        }

        public Task<bool> CreateAnimal(AnimalData animal)
        {
            try
            {

            }
            catch (Exception e)
            {
                throw new DomainException(e.Message);
            }
        }

        public Task<List<Animal>> GetAllAnimals()
        {
            try
            {

            }
            catch (Exception e)
            {
                throw new DomainException(e.Message);
            }
        }

        public Task<List<Animal>> GetAnimalsFromAUser(string userId)
        {
            try
            {

            }
            catch (Exception e)
            {
                throw new DomainException(e.Message);
            }
        }
    }
}
