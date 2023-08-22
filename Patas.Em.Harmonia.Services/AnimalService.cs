﻿using FluentValidation;
using Patas.Em.Harmonia.Domain.Constants;
using Patas.Em.Harmonia.Domain.Exceptions;
using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models;
using Patas.Em.Harmonia.Domain.Models.Entities;

namespace Patas.Em.Harmonia.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UserBaseData> _validator;

        public AnimalService(IUserRepository userRepository, IValidator<UserBaseData> validator)
        {
            _userRepository = userRepository;
            _validator = validator;
        }

        public Task<bool> ChangeAnimalState(string status)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        public Task<List<Animal>> GetAllAnimals()
        {
            throw new NotImplementedException();
        }

        public Task<List<Animal>> GetAnimalsFromAUser(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByMail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new DomainException(Constant.EMAIL_EMPTY_WARNING);
            }

            var user = await _userRepository.GetUserByMail(email);

            return user;
        }
    }
}
