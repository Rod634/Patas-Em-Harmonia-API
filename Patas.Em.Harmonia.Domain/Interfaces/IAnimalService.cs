using Patas.Em.Harmonia.Domain.Models.DTO;
using Patas.Em.Harmonia.Domain.Models.Entities;

namespace Patas.Em.Harmonia.Domain.Interfaces
{
    public interface IAnimalService
    {
        /// <summary>
        /// Get animal by user
        /// </summary>
        /// <returns>Returns an User Animals</returns>
        Task<List<Animal>> GetAnimalsFromAUser(int userId);

        /// <summary>
        /// Get all animals
        /// </summary>
        /// <returns>Returns all animals</returns>
        Task<List<Animal>> GetAllAnimals();

        /// <summary>
        /// Create a animal
        /// </summary>
        /// <returns>A bool that indicates success or not</returns>
        Task<bool> CreateAnimal(AnimalDto animal);

        /// <summary>
        /// ChangeAnimalStatus
        /// </summary>
        /// <returns>A bool that indicates success or not</returns>
        Task<bool> ChangeAnimalStatus(string status, int animalId);
    }
}
