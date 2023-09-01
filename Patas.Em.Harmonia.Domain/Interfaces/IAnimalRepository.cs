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
        Task<List<Animal>> GetAllAnimalsFromAnUser(string idUser);

        /// <summary>
        /// Change An animal status
        /// </summary>
        /// <returns>A bool that indicates success or not</returns>
        Task<bool> ChangeAnAnimalStatus(string status, string animalId);

        /// <summary>
        /// Create an Animal
        /// </summary>
        /// <returns>A bool that indicates success or not</returns>
        Task<bool> CreateAnimal(Animal animal);
    }
}
