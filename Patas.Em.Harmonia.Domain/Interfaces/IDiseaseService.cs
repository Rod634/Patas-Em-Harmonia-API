namespace Patas.Em.Harmonia.Domain.Interfaces
{
    public interface IDiseaseService
    {
        /// <summary>
        /// Get all Disease names
        /// </summary>
        /// <returns>Returns a list with all Disease names</returns>
        Task<List<string>> GetAllDiseaseNames();
    }
}
