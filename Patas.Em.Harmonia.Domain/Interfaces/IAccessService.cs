using Patas.Em.Harmonia.Domain.Models.DTO;
using Patas.Em.Harmonia.Domain.Models.Entities;

namespace Patas.Em.Harmonia.Domain.Interfaces
{
    public interface IAccessService
    {
        /// <summary>
        /// Get user Login
        /// </summary>
        /// <returns>Returns an User Data</returns>
        Task<User> UserLogin(LoginDto login);
    }
}
