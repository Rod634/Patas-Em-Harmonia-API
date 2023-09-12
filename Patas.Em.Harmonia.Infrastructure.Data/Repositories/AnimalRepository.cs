using Microsoft.EntityFrameworkCore;
using Patas.Em.Harmonia.Domain.Constants;
using Patas.Em.Harmonia.Domain.Interfaces;
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

        public async Task<bool> UpdateAnAnimal(Animal animal)
        {
            var databaseAnimal = await _patasDBContext.Animals.FirstOrDefaultAsync(a => a.Id.Equals(animal.Id));
            if (databaseAnimal is not null)
            {
                await _repositoryBase.UpdateAsync(animal);
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
            return await _patasDBContext.Animals.Include(a => a.DiseaseAnimals).Include(a => a.VaccineAnimals).ToListAsync();
        }

        public async Task<List<Animal>> GetAllAnimalsFromAnUser(string idUser, string ngoId)
        {
            var animals = await _patasDBContext.Animals.Include(a => a.DiseaseAnimals).Include(a => a.VaccineAnimals).
                Where(x => (x.IdUser.Equals(idUser) || x.NgoId.Equals(ngoId)) && x.Status == Constant.ACTIVE).ToListAsync();
            return animals;
        }
    }
}
