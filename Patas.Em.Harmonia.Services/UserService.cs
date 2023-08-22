using FluentValidation;
using Patas.Em.Harmonia.Domain.Constants;
using Patas.Em.Harmonia.Domain.Exceptions;
using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models;
using Patas.Em.Harmonia.Domain.Models.Entities;

namespace Patas.Em.Harmonia.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UserModel> _validator;

        public UserService(IUserRepository userRepository, IValidator<UserModel> validator)
        {
            _userRepository = userRepository;
            _validator = validator;
        }

        public async Task<User> ChangeUserData(UserModel userNewData)
        {
            try
            {
                _validator.ValidateAndThrow(userNewData);
                var user = await _userRepository.ChangeUserData(userNewData);
                return user;

            }catch(Exception e)
            {
                throw new DomainException(e.Message);
            }
        }

        public async Task<bool> CreateUser(UserModel user)
        {
            try
            {
                _validator.ValidateAndThrow(user);

                var newUser = new User(user);
                var isSuccess = await _userRepository.CreateUser(newUser);

                return isSuccess;
            }
            catch (Exception e)
            {
                throw new DomainException(e.Message);
            }
        }

        public async Task<bool> DeleteUserByEmail(string email)
        {
            if(string.IsNullOrEmpty(email))
            {
                throw new DomainException(Constant.EMAIL_EMPTY_WARNING);
            }

            var isSuccess = await _userRepository.DeleteUserByEmail(email);

            return isSuccess;
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
