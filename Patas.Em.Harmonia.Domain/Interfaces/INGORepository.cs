using Patas.Em.Harmonia.Domain.Models.Entities;

namespace Patas.Em.Harmonia.Domain.Interfaces
{
    public interface INGORepository
    {
        /// <summary>
        /// Create a NGO
        /// </summary>
        /// <returns>A bool that indicates success or not</returns>
        Task<bool> CreateNGO(Ngo ngo);

        /// <summary>
        /// Get all NGO's
        /// </summary>
        /// <returns>A List with NGO's</returns>
        Task<List<Ngo>> GetAllNGOs();

        /// <summary>
        /// Get NGO By email
        /// </summary>
        /// <returns>A NGO's by email</returns>
        Task<Ngo> GetNGOByEmail(string email);
    }
}
