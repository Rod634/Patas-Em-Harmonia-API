using Patas.Em.Harmonia.Domain.Interfaces;

namespace Patas.Em.Harmonia.Services
{
    public class VaccineService : IVaccineService
    {
        private readonly IVaccineRepository _vaccineRepository;

        public VaccineService(IVaccineRepository vaccineRepository)
        {
            _vaccineRepository = vaccineRepository;
        }

        public Task<List<string>> GetAllVaccines()
        {
            return _vaccineRepository.GetAllVaccines();
        }
    }
}
