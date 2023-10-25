using FluentValidation;
using Patas.Em.Harmonia.Domain.Exceptions;
using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models.DTO;
using Patas.Em.Harmonia.Domain.Models.Entities;

namespace Patas.Em.Harmonia.Services
{
    public class AccessService : IAccessService
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<LoginDto> _validator;

        public AccessService(IUserRepository userRepository, IValidator<LoginDto> validator)
        {
            _userRepository = userRepository;
            _validator = validator;
        }

        public async Task<User> UserLogin(LoginDto loginDto)
        {
            try
            {
                _validator.ValidateAndThrow(loginDto);
                var user = await _userRepository.GetUserByMail(loginDto.Email);
                if(user is not null && BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Passwrd))
                {
                    return user;
                }
                return new User();
            }
            catch(Exception e)
            {
                throw new DomainException(e.Message);
            }
        }
    }
}
