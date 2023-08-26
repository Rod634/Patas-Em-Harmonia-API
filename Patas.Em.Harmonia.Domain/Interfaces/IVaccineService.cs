
namespace Patas.Em.Harmonia.Domain.Interfaces
{
    public interface IVaccineService
    {
        /// <summary>
        /// Get all vaccine names
        /// </summary>
        /// <returns>Returns a list with all vaccine names</returns>
        Task<List<string>> GetAllVaccines();
    }
}
