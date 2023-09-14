using Patas.Em.Harmonia.Domain.Models.DTO;
using Patas.Em.Harmonia.Domain.Models.Entities;

namespace Patas.Em.Harmonia.Domain.Interfaces
{
    public interface IVaccineRepository
    {
        /// <summary>
        /// Get an user data by email
        /// </summary>
        /// <returns>Returns a list with all vaccines</returns>
        Task<List<NameIdDto>> GetAllVaccines();

        /// <summary>
        /// Bind a animal with a vaccine
        /// </summary>
        /// <returns>A bool that indicates success or not</returns>
        Task<bool> AddAnimalVaccine(VaccineAnimal vaccineAnimal);

        /// <summary>
        /// Change a vaccine 
        /// </summary>
        /// <returns>A bool that indicates success or not</returns>
        Task<bool> ChangeAnimalVaccine(ChangeVaccineDto vaccineAnimal);
    }
}
