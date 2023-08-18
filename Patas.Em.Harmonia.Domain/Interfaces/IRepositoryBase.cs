namespace Patas.Em.Harmonia.Domain.Interfaces
{
    public interface IRepositoryBase
    {
        /// <summary>
        /// Update record
        /// </summary>
        Task UpdateAsync<T>(T entity) where T : class;

        /// <summary>
        /// Save data
        /// </summary>
        Task SaveAsync<T>(T entity) where T : class;

        /// <summary>
        /// Save Range data
        /// </summary>
        Task SaveRangeAsync<T>(IEnumerable<T> entity) where T : class;

        /// <summary>
        /// Delete record
        /// </summary>
        Task DeleteAsync<T>(T entity) where T : class;
    }
}