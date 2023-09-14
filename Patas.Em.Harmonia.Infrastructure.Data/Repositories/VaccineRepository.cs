﻿using Microsoft.EntityFrameworkCore;
using Patas.Em.Harmonia.Domain.Interfaces;
using Patas.Em.Harmonia.Domain.Models.DTO;
using Patas.Em.Harmonia.Domain.Models.Entities;
using Patas.Em.Harmonia.Infrastructure.Data.Context;

namespace Patas.Em.Harmonia.Infrastructure.Data.Repositories
{
    public class VaccineRepository : IVaccineRepository
    {
        private readonly PatasDBContext _patasDBContext;
        private readonly IRepositoryBase _repositoryBase;

        public VaccineRepository(PatasDBContext patasDBContext, IRepositoryBase repositoryBase)
        {
            _patasDBContext = patasDBContext;
            _repositoryBase = repositoryBase;
        }

        public async Task<bool> AddAnimalVaccine(VaccineAnimal vaccineAnimal)
        {
            try
            {
                await _repositoryBase.SaveAsync(vaccineAnimal);
                return true;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> ChangeAnimalVaccine(ChangeVaccineDto vaccineAnimal)
        {
            try
            {
                var vaccineDatabase = _patasDBContext.VaccineAnimals.FirstOrDefault(v => v.Id == vaccineAnimal.Id);
                if(vaccineDatabase is not null)
                {
                    vaccineDatabase.DtVaccine = vaccineAnimal.DtVaccine;
                    vaccineDatabase.IdVaccine = vaccineAnimal.IdVaccine;
      

                    await _repositoryBase.UpdateAsync(vaccineDatabase);
                    return true;
                }
               return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<List<NameIdDto>> GetAllVaccines()
        {
            return _patasDBContext.Vaccines.Select(v => new NameIdDto() { Id = v.Id, Name = v.Name }).ToListAsync();
        }
    }
}
