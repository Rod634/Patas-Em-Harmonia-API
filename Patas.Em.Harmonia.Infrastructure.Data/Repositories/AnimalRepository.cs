using Microsoft.EntityFrameworkCore;
using Patas.Em.Harmonia.Domain.Constants;
using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models.DTO;
using Patas.Em.Harmonia.Domain.Models.Entities;
using Patas.Em.Harmonia.Infrastructure.Data.Context;

namespace Patas.Em.Harmonia.Infrastructure.Data.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly IRepositoryBase _repositoryBase;
        private readonly PatasDBContext _patasDBContext;

        public AnimalRepository(IRepositoryBase repositoryBase, PatasDBContext patasDBContext)
        {
            _repositoryBase = repositoryBase;
            _patasDBContext = patasDBContext;
        }

        public async Task<bool> UpdateAnAnimal(UpdateAnimalDto animal)
        {
            var databaseAnimal = await _patasDBContext.Animals.FirstOrDefaultAsync(a => a.Id.Equals(animal.IdAnimal));
            if (databaseAnimal is not null)
            {
                databaseAnimal.Name = animal.Name;
                databaseAnimal.Gender = animal.Gender;
                databaseAnimal.Errant = animal.Errant;
                databaseAnimal.Race = animal.Race;
                databaseAnimal.Age = animal.Age;
                databaseAnimal.PhotoUrl = animal.PhotoUrl;
                databaseAnimal.Species = animal.Species;
                databaseAnimal.Status = animal.Status;
                databaseAnimal.NgoId = animal.NgoId;
                databaseAnimal.Neighborhood = animal.Neighborhood;
                databaseAnimal.LatitudeLongitude = animal.LatitudeLongitude;

                await _repositoryBase.UpdateAsync(databaseAnimal);
                return true;
            }
            return false;
        }

        public async Task<bool> CreateAnimal(Animal animal)
        {
            try
            {
                await _repositoryBase.SaveAsync(animal);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Animal>> GetAllAnimals()
        {
            return await _patasDBContext.Animals.Where(a => a.Status.Equals(Constant.ACTIVE)).Include(a => a.DiseaseAnimals).Include(a => a.VaccineAnimals).ToListAsync();
        }

        public async Task<List<Animal>> GetAllAnimalsFromAnUser(string idUser, string? ngoId)
        {
            var animals = await _patasDBContext.Animals.Include(a => a.DiseaseAnimals).Include(a => a.VaccineAnimals).
                Where(x => (x.IdUser.Equals(idUser) || x.NgoId.Equals(ngoId)) && x.Status == Constant.ACTIVE).ToListAsync();
            return animals;
        }
    }
}
