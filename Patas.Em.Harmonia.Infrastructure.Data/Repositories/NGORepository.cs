using Microsoft.EntityFrameworkCore;
using Patas.Em.Harmonia.Domain.Constants;
using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models.Entities;
using Patas.Em.Harmonia.Infrastructure.Data.Context;

namespace Patas.Em.Harmonia.Infrastructure.Data.Repositories
{
    public class NgoRepository : INgoRepository
    {
        private readonly IRepositoryBase _repositoryBase;
        private readonly PatasDBContext _patasDBContext;

        public NgoRepository(IRepositoryBase repositoryBase, PatasDBContext patasDBContext)
        {
            _repositoryBase = repositoryBase;
            _patasDBContext = patasDBContext;
        }

        public async Task<bool> CreateNgo(Ngo ngo)
        {
            var databaseNgo = await GetNgoByEmail(ngo.Email);
            if (databaseNgo != null)
            {
                return false;
            }
            await _repositoryBase.SaveAsync(ngo);
            return true;
        }

        public async Task<List<Ngo>> GetAllNgos()
        {
            return await _patasDBContext.Ngos.Where(n=> n.Status.Equals(Constant.ACTIVE)).ToListAsync();
        }

        public async Task<Ngo> GetNgoByEmail(string email)
        {
            var ngo = await _patasDBContext.Ngos.Where(n => n.Email.Equals(email)).FirstOrDefaultAsync();
            return ngo;
        }
    }
}
