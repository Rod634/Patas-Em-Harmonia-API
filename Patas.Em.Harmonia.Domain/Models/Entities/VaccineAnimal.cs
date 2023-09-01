#nullable disable

using Patas;

namespace Patas.Em.Harmonia.Domain.Models.Entities
{
    public partial class VaccineAnimal
    {
        public string Id { get; set; }
        public string IdAnimal { get; set; }
        public int IdVaccine { get; set; }
        public DateTime DtVaccine { get; set; }

        public virtual Animal IdAnimalNavigation { get; set; }
        public virtual Vaccine IdVaccineNavigation { get; set; }
    }
}