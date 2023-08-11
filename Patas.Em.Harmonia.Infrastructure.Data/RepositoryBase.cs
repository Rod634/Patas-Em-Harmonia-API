using Patas.Em.Harmonia.Infrastructure.Data.Context;
using Patas.Em.Harmonia.Infrastructure.Data.Interfaces;

namespace Patas.Em.Harmonia.Infrastructure.Data
{
    public class RepositoryBase : IRepositoryBase
    {
        private readonly PatasDBContext _patasDBContext;

        public RepositoryBase(PatasDBContext patasDBContext)
        {
            _patasDBContext = patasDBContext;
        }

        public async Task SaveAsync<T>(T entity) where T : class
        {
            _patasDBContext.Add(entity);
            await SaveChangesAsync();
        }

        public async Task SaveRangeAsync<T>(IEnumerable<T> entity) where T : class
        {
            _patasDBContext.AddRange(entity);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            _patasDBContext.Update(entity);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            _patasDBContext.Remove(entity);
            await SaveChangesAsync();
        }

        private async Task SaveChangesAsync()
        {
            await _patasDBContext.SaveChangesAsync();
        }
    }
}
