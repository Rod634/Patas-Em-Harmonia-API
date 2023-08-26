namespace Patas.Em.Harmonia.Domain.Interfaces
{
    public interface IDiseaseRepository
    {
        /// <summary>
        /// Get all Diseases
        /// </summary>
        /// <returns>Returns a list with all disease names</returns>
        Task<List<string>> GetAllDiseaseNames();
    }
}
