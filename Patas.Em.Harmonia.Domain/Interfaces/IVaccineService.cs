using Patas.Em.Harmonia.Domain.Models.DTO;

namespace Patas.Em.Harmonia.Domain.Interfaces
{
    public interface IVaccineService
    {
        /// <summary>
        /// Get all vaccine names
        /// </summary>
        /// <returns>Returns a list with all vaccine names</returns>
        Task<List<NameIdDto>> GetAllVaccines();

        /// <summary>
        /// Bind a new vaccine to an animal
        /// </summary>
        /// <returns>Returns a bool that indicates success</returns>
        Task<bool> CreateVaccineAnimall(VaccineDto vaccineDto, string animalId);

        /// <summary>
        /// Change a vaccine 
        /// </summary>
        /// <returns>Returns a bool that indicates success</returns>
        Task<bool> ChangeVaccineAnimall(ChangeVaccineDto vaccineDto);
    }
}
