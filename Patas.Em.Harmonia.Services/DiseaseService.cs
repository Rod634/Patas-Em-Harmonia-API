using Patas.Em.Harmonia.Domain.Interfaces;

namespace Patas.Em.Harmonia.Services
{
    public class DiseaseService : IDiseaseService
    {
        private readonly IDiseaseRepository _diseaseRepository;

        public DiseaseService(IDiseaseRepository diseaseRepository)
        {
            _diseaseRepository = diseaseRepository;
        }

        public Task<List<string>> GetAllDiseaseNames()
        {
            return _diseaseRepository.GetAllDiseaseNames();
        }
    }
}
