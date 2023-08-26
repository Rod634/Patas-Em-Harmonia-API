namespace Patas.Em.Harmonia.Domain.Interfaces
{
    public interface IVaccineRepository
    {
        /// <summary>
        /// Get an user data by email
        /// </summary>
        /// <returns>Returns a list with all vaccines</returns>
        Task<List<string>> GetAllVaccines();
    }
}
