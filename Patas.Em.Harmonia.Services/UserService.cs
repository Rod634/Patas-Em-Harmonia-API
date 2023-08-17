using FluentValidation;
using Patas.Em.Harmonia.Domain.Constants;
using Patas.Em.Harmonia.Domain.Exceptions;
using Patas.Em.Harmonia.Domain.Models;
using Patas.Em.Harmonia.Infrastructure.Data.Interfaces;
using Patas.Em.Harmonia.Infrastructure.Data.Models;
using Patas.Em.Harmonia.Services.Interfaces;

namespace Patas.Em.Harmonia.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UserBaseData> _validator;

        public UserService(IUserRepository userRepository, IValidator<UserBaseData> validator)
        {
            _userRepository = userRepository;
            _validator = validator;
        }

        public async Task<User> ChangeUserData(UserBaseData userNewData)
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

        public async Task<bool> CreateUser(UserBaseData user)
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
            if(email == null)
            {
                throw new DomainException(Constants.EMAIL_EMPTY_WARNING);
            }

            var isSuccess = await _userRepository.DeleteUserByEmail(email);

            return isSuccess;
        }

        public async Task<User> GetUserByMail(string email)
        {
            if (email == null)
            {
                throw new DomainException(Constants.EMAIL_EMPTY_WARNING);
            }

            var user = await _userRepository.GetUserByMail(email);

            return user;
        }
    }
}
