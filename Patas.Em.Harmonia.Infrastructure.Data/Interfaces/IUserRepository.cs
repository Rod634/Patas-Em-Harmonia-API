using Patas.Em.Harmonia.Infrastructure.Data.Models;

namespace Patas.Em.Harmonia.Infrastructure.Data.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Get an user data by email
        /// </summary>
        /// <returns>Returns an User Data</returns>
        Task<User> GetUserByMail(string email);

        /// <summary>
        /// Change a user info
        /// </summary>
        /// <returns>An user with the new data</returns>
        Task<User> ChangeUserData(User userNewData);

        /// <summary>
        /// Delete a user by mail
        /// </summary>
        /// <returns>A bool that indicates success or not</returns>
        Task<bool> DeleteUserByEmail(string email);
    }
}
