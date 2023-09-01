#nullable disable

using Patas.Em.Harmonia.Domain.Models.DTO;

namespace Patas.Em.Harmonia.Domain.Models.Entities
{
    public partial class VaccineAnimal
    {
        public int Id { get; set; }
        public string IdAnimal { get; set; }
        public int IdVaccine { get; set; }
        public DateTime DtVaccine { get; set; }

        public static explicit operator VaccineAnimal(VaccineDto vaccine)
        {
            return new()
            {
                IdAnimal = vaccine.IdAnimal,
                IdVaccine = vaccine.IdVaccine,
                DtVaccine = vaccine.DtVaccine
            };
        }

        public virtual Animal IdAnimalNavigation { get; set; }
        public virtual Vaccine IdVaccineNavigation { get; set; }
    }
}