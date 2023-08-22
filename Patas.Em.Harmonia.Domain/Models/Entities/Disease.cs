#nullable disable

using Patas;

namespace Patas.Em.Harmonia.Domain.Models.Entities
{
    public partial class Disease
    {
        public Disease()
        {
            DiseaseAnimals = new HashSet<DiseaseAnimal>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DiseaseAnimal> DiseaseAnimals { get; set; }
    }
}