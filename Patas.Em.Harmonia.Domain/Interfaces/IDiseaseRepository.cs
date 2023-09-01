using Patas.Em.Harmonia.Domain.Models.Entities;

namespace Patas.Em.Harmonia.Domain.Interfaces
{
    public interface IDiseaseRepository
    {
        /// <summary>
        /// Get all Diseases
        /// </summary>
        /// <returns>Returns a list with all disease names</returns>
        Task<List<string>> GetAllDiseaseNames();

        /// <summary>
        /// Bind a animal with a Disease in database
        /// </summary>
        /// <returns>A bool that indicates success or not</returns>
        Task<bool> AddAnimalDisease(DiseaseAnimal diseaseAnimal);
    }
}
