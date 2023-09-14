using Patas.Em.Harmonia.Domain.Models.DTO;
using Patas.Em.Harmonia.Domain.Models.Entities;

namespace Patas.Em.Harmonia.Domain.Interfaces
{
    public interface IDiseaseRepository
    {
        /// <summary>
        /// Get all Diseases
        /// </summary>
        /// <returns>Returns a list with all disease names</returns>
        Task<List<NameIdDto>> GetAllDiseaseNames();

        /// <summary>
        /// Bind a animal with a Disease in database
        /// </summary>
        /// <returns>A bool that indicates success or not</returns>
        Task<bool> AddAnimalDisease(DiseaseAnimal diseaseAnimal);

        /// <summary>
        /// Change a Disease 
        /// </summary>
        /// <returns>A bool that indicates success or not</returns>
        Task<bool> ChangeAnimalDisease(ChangeDiseaseDto changeDiseaseDto);
    }
}
