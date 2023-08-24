#nullable disable

using Patas;

namespace Patas.Em.Harmonia.Domain.Models.Entities
{
    public partial class DiseaseAnimal
    {
        public int Id { get; set; }
        public int IdAnimal { get; set; }
        public int IdDisease { get; set; }
        public int IdStatus { get; set; }

        public virtual Animal IdAnimalNavigation { get; set; }
        public virtual Disease IdDiseaseNavigation { get; set; }
        public virtual Status IdStatusNavigation { get; set; }
    }
}