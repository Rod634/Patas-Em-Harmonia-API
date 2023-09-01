﻿using Patas.Em.Harmonia.Domain.Models.DTO;

namespace Patas.Em.Harmonia.Domain.Interfaces
{
    public interface IStatusRepository
    {
        /// <summary>
        /// Get all status
        /// </summary>
        /// <returns>Returns a list with all status</returns>
        Task<List<NameIdDto>> GetAllStatus();
    }
}
