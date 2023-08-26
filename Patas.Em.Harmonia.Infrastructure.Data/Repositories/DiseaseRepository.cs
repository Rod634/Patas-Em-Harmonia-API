using Microsoft.EntityFrameworkCore;
using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Infrastructure.Data.Context;

namespace Patas.Em.Harmonia.Infrastructure.Data.Repositories
{
    public class DiseaseRepository : IDiseaseRepository
    {
        private readonly PatasDBContext _patasDBContext;

        public DiseaseRepository(PatasDBContext patasDBContext)
        {
            _patasDBContext = patasDBContext;
        }

        public Task<List<string>> GetAllDiseaseNames()
        {
            return _patasDBContext.Diseases.Select(d => d.Name).ToListAsync();
        }
    }
}
