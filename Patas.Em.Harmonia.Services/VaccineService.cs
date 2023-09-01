using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models.DTO;

namespace Patas.Em.Harmonia.Services
{
    public class VaccineService : IVaccineService
    {
        private readonly IVaccineRepository _vaccineRepository;

        public VaccineService(IVaccineRepository vaccineRepository)
        {
            _vaccineRepository = vaccineRepository;
        }

        public Task<List<NameIdDto>> GetAllVaccines()
        {
            return _vaccineRepository.GetAllVaccines();
        }
    }
}
