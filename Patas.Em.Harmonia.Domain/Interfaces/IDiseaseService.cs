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

        /// <summary>
        /// Bind a new disease to an animal
        /// </summary>
        /// <returns>Returns a bool that indicates success</returns>
        Task<bool> CreateDiseaseAnimall(DiseaseDto disease, string animalId);

        /// <summary>
        /// Change a disease 
        /// </summary>
        /// <returns>Returns a bool that indicates success</returns>
        Task<bool> ChangeDiseaseAnimall(ChangeDiseaseDto diseaseDto);
    }
}
