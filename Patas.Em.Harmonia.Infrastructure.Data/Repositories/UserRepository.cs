using Microsoft.EntityFrameworkCore;
using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models;
using Patas.Em.Harmonia.Domain.Models.Entities;
using Patas.Em.Harmonia.Infrastructure.Data.Context;


namespace Patas.Em.Harmonia.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IRepositoryBase _repositoryBase;
        private readonly PatasDBContext _patasDBContext;

        public UserRepository(IRepositoryBase repositoryBase, PatasDBContext patasDBContext)
        {
            _repositoryBase = repositoryBase;
            _patasDBContext = patasDBContext;
        }

        public async Task<User> ChangeUserData(UserModel userNewData)
        {
            var user = await GetUserByMail(userNewData.Email);

            if (user == null)
            {
                return new User();
            }

            user.Name = userNewData.Name;
            user.NgoName = userNewData.NgoName;
            user.HasPets = userNewData.HasPets;
            user.AditionalInfo = userNewData.AditionalInfo;
            user.Email = userNewData.Email;
            user.Status = userNewData.Status;
            user.Phone = userNewData.Phone;

            await _repositoryBase.UpdateAsync(user);

            return user;
        }

        public async Task<bool> CreateUser(User user)
        {
            var databaseUser = await GetUserByMail(user.Email);
            if (databaseUser != null)
            {
                return false;
            }
            await _repositoryBase.SaveAsync(user);
            return true;
        }

        public async Task<bool> DeleteUserByEmail(string email)
        {
            var user = await GetUserByMail(email);

            if (user == null)
            {
                return false;
            }

            await _repositoryBase.DeleteAsync(user);
            return true;
        }

        public async Task<User> GetUserByMail(string email)
        {
            var user = await _patasDBContext.Users.Where(u => u.Email.Equals(email)).FirstOrDefaultAsync();
            return user;
        }
    }
}
