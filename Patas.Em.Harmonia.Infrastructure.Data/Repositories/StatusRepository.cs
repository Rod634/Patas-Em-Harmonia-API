using Microsoft.EntityFrameworkCore;
using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models.DTO;
using Patas.Em.Harmonia.Infrastructure.Data.Context;

namespace Patas.Em.Harmonia.Infrastructure.Data.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly PatasDBContext _patasDBContext;

        public StatusRepository(PatasDBContext patasDBContext)
        {
            _patasDBContext = patasDBContext;
        }

        public Task<List<NameIdDto>> GetAllStatus()
        {
            return _patasDBContext.Statuses.Select(s => new NameIdDto() { Id = s.Id, Name = s.Name}).ToListAsync();
        }
    }
}
