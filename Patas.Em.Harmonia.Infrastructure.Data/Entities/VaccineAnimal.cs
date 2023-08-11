#nullable disable

namespace Patas.Em.Harmonia.Infrastructure.Data.Models
{
    public partial class VaccineAnimal
    {
        public int Id { get; set; }
        public int IdAnimal { get; set; }
        public int IdVaccine { get; set; }
        public DateTime DtVaccine { get; set; }

        public virtual Animal IdAnimalNavigation { get; set; }
        public virtual Vaccine IdVaccineNavigation { get; set; }
    }
}