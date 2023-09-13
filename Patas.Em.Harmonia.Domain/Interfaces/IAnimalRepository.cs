using Patas.Em.Harmonia.Domain.Models.DTO;
using Patas.Em.Harmonia.Domain.Models.Entities;

namespace Patas.Em.Harmonia.Domain.Interfaces
{
    public interface IAnimalRepository
    {
        /// <summary>
        /// Get all animals
        /// </summary>
        /// <returns>Returns a list of animals</returns>
        Task<List<Animal>> GetAllAnimals();

        /// <summary>
        /// Get all animals from an user
        /// </summary>
        /// <returns>Returns a list of animals</returns>
        Task<List<Animal>> GetAllAnimalsFromAnUser(string idUser, string ngoId);

        /// <summary>
        /// Change An animal status
        /// </summary>
        /// <returns>A bool that indicates success or not</returns>
        Task<bool> UpdateAnAnimal(UpdateAnimalDto animal);

        /// <summary>
        /// Create an Animal
        /// </summary>
        /// <returns>A bool that indicates success or not</returns>
        Task<bool> CreateAnimal(Animal animal);
    }
}
