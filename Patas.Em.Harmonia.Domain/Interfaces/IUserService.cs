﻿using Patas.Em.Harmonia.Domain.Models;
using Patas.Em.Harmonia.Domain.Models.Entities;

namespace Patas.Em.Harmonia.Domain.Interfaces
{
    public interface IUserService
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
        Task<User> ChangeUserData(UserData userNewData);

        /// <summary>
        /// Delete a user by mail
        /// </summary>
        /// <returns>A bool that indicates success or not</returns>
        Task<bool> DeleteUserByEmail(string email);

        /// <summary>
        /// Create a user
        /// </summary>
        /// <returns>A bool that indicates success or not</returns>
        Task<bool> CreateUser(UserData user);
    }
}
