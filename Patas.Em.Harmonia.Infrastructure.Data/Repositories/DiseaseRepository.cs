using Microsoft.EntityFrameworkCore;
using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models.DTO;
using Patas.Em.Harmonia.Domain.Models.Entities;
using Patas.Em.Harmonia.Infrastructure.Data.Context;

namespace Patas.Em.Harmonia.Infrastructure.Data.Repositories
{
    public class DiseaseRepository : IDiseaseRepository
    {
        private readonly PatasDBContext _patasDBContext;
        private readonly IRepositoryBase _repositoryBase;

        public DiseaseRepository(PatasDBContext patasDBContext, IRepositoryBase repositoryBase)
        {
            _patasDBContext = patasDBContext;
            _repositoryBase = repositoryBase;
        }

        public async Task<bool>  AddAnimalDisease(DiseaseAnimal diseaseAnimal)
        {
            try
            {
                await _repositoryBase.SaveAsync(diseaseAnimal);
                return true;
            }catch
            {
                return false;
            }
        }

        public async Task<bool> ChangeAnimalDisease(ChangeDiseaseDto diseaseDto)
        {
            try
            {
                var diseaseDatabase = _patasDBContext.DiseaseAnimals.FirstOrDefault(v => v.Id == diseaseDto.Id);
                if (diseaseDatabase is not null)
                {
                    diseaseDatabase.IdDisease = diseaseDto.IdDisease;
                    diseaseDatabase.IdStatus = diseaseDto.IdStatus;


                    await _repositoryBase.UpdateAsync(diseaseDatabase);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<List<NameIdDto>> GetAllDiseaseNames()
        {
            return _patasDBContext.Diseases.Select(d => new NameIdDto() { Id = d.Id, Name = d.Name }).ToListAsync();
        }
    }
}
