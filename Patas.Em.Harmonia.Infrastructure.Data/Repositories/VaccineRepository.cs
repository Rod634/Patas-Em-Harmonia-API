using Microsoft.EntityFrameworkCore;
using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models;
using Patas.Em.Harmonia.Domain.Models.Entities;
using Patas.Em.Harmonia.Infrastructure.Data.Context;

namespace Patas.Em.Harmonia.Infrastructure.Data.Repositories
{
    public class VaccineRepository : IVaccineRepository
    {
        private readonly PatasDBContext _patasDBContext;

        public VaccineRepository(PatasDBContext patasDBContext)
        {
            _patasDBContext = patasDBContext;
        }

        public Task<List<string>> GetAllVaccines()
        {
            return _patasDBContext.Vaccines.Select(v => v.Name).ToListAsync();
        }
    }
}
