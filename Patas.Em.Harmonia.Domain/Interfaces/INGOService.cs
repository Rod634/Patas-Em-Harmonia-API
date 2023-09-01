using Patas.Em.Harmonia.Domain.Models.DTO;
using Patas.Em.Harmonia.Domain.Models.Entities;

namespace Patas.Em.Harmonia.Domain.Interfaces
{
    public interface INgoService
    {
        /// <summary>
        /// Create a NGO
        /// </summary>
        /// <returns>A bool that indicates success or not</returns>
        Task<bool> CreateNgo(NgoDto ngo);

        /// <summary>
        /// Get all NGO's
        /// </summary>
        /// <returns>A list with all NGO</returns>
        Task<List<Ngo>> GetAllNgos();

    }
}
