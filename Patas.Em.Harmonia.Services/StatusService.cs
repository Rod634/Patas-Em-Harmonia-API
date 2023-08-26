using Patas.Em.Harmonia.Domain.Interfaces;

namespace Patas.Em.Harmonia.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public Task<List<string>> GetAllStatus()
        {
            return _statusRepository.GetAllStatus();
        }
    }
}
