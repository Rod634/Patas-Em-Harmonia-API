
namespace Patas.Em.Harmonia.Domain.Interfaces
{
    public interface IStatusService
    {
        /// <summary>
        /// Get all status names
        /// </summary>
        /// <returns>Returns a list with all status names</returns>
        Task<List<string>> GetAllStatus();
    }
}
