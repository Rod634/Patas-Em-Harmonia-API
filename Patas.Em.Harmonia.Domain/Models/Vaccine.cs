#nullable disable

namespace Patas.Em.Harmonia.Domain.Models
{
    public partial class Vaccine
    {
        public Vaccine()
        {
            VaccineAnimals = new HashSet<VaccineAnimal>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<VaccineAnimal> VaccineAnimals { get; set; }
    }
}