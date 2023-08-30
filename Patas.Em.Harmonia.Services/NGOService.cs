using FluentValidation;
using Patas.Em.Harmonia.Domain.Exceptions;
using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models.DTO;
using Patas.Em.Harmonia.Domain.Models.Entities;

namespace Patas.Em.Harmonia.Services
{
    public class NgoService : INgoService
    {
        private readonly INgoRepository _nGORepository;
        private readonly IValidator<NgoDto> _validator;

        public NgoService(INgoRepository nGORepository, IValidator<NgoDto> validator)
        {
            _nGORepository = nGORepository;
            _validator = validator;
        }

        public async Task<bool> CreateNgo(NgoDto ngo)
        {
            try
            {
                _validator.ValidateAndThrow(ngo);

                var newNgo = (Ngo)ngo;
                var isSuccess = await _nGORepository.CreateNgo(newNgo);

                return isSuccess;
            }
            catch (Exception e)
            {
                throw new DomainException(e.Message);
            }
        }

        public Task<List<Ngo>> GetAllNgos()
        {
            return _nGORepository.GetAllNgos();
        }
    }
}
