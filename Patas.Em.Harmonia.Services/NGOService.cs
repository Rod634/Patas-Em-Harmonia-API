using FluentValidation;
using Patas.Em.Harmonia.Domain.Exceptions;
using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models;
using Patas.Em.Harmonia.Domain.Models.Entities;

namespace Patas.Em.Harmonia.Services
{
    public class NGOService : INGOService
    {
        private readonly INGORepository _nGORepository;
        private readonly IValidator<NgoData> _validator;

        public NGOService(INGORepository nGORepository, IValidator<NgoData> validator)
        {
            _nGORepository = nGORepository;
            _validator = validator;
        }

        public async Task<bool> CreateNgo(NgoData ngo)
        {
            try
            {
                _validator.ValidateAndThrow(ngo);

                var newNgo = new Ngo(ngo);
                var isSuccess = await _nGORepository.CreateNGO(newNgo);

                return isSuccess;
            }
            catch (Exception e)
            {
                throw new DomainException(e.Message);
            }
        }

        public Task<List<Ngo>> GetAllNgos()
        {
            return _nGORepository.GetAllNGOs();
        }
    }
}
