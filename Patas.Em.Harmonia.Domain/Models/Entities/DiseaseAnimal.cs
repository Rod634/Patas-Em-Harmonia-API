#nullable disable

using Patas.Em.Harmonia.Domain.Models.DTO;

namespace Patas.Em.Harmonia.Domain.Models.Entities
{
    public partial class DiseaseAnimal
    {
        public int Id { get; set; }
        public string IdAnimal { get; set; }
        public int IdDisease { get; set; }
        public int IdStatus { get; set; }

        public static explicit operator DiseaseAnimal(DiseaseDto disease)
        {
            return new()
            {
                IdDisease = disease.IdDisease,
                IdStatus = disease.IdStatus
            };
        }
        public virtual Animal IdAnimalNavigation { get; set; }
        public virtual Disease IdDiseaseNavigation { get; set; }
        public virtual Status IdStatusNavigation { get; set; }
    }
}