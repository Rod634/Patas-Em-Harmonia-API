using Patas.Em.Harmonia.Domain.Models.DTO;

namespace Patas.Em.Harmonia.Domain.Interfaces
{
    public interface IDiseaseService
    {
        /// <summary>
        /// Get all Disease names
        /// </summary>
        /// <returns>Returns a list with all Disease names</returns>
        Task<List<NameIdDto>> GetAllDiseaseNames();
    }
}
