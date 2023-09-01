using Microsoft.EntityFrameworkCore;
using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models.Entities;
using Patas.Em.Harmonia.Infrastructure.Data.Context;

namespace Patas.Em.Harmonia.Infrastructure.Data.Repositories
{
    public class VaccineRepository : IVaccineRepository
    {
        private readonly PatasDBContext _patasDBContext;
        private readonly IRepositoryBase _repositoryBase;

        public VaccineRepository(PatasDBContext patasDBContext, IRepositoryBase repositoryBase)
        {
            _patasDBContext = patasDBContext;
            _repositoryBase = repositoryBase;
        }

        public async Task<bool> AddAnimalVaccine(VaccineAnimal vaccineAnimal)
        {
            try
            {
                await _repositoryBase.SaveAsync(vaccineAnimal);
                return true;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
                return false;
            }
        }

        public Task<List<string>> GetAllVaccines()
        {
            return _patasDBContext.Vaccines.Select(v => v.Name).ToListAsync();
        }
    }
}
