#nullable disable

namespace Patas.Em.Harmonia.Infrastructure.Data.Models
{
    public partial class Animal
    {
        public Animal()
        {
            DiseaseAnimals = new HashSet<DiseaseAnimal>();
            VaccineAnimals = new HashSet<VaccineAnimal>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Race { get; set; }
        public string Species { get; set; }
        public string Gender { get; set; }
        public bool Errant { get; set; }
        public string PhotoUrl { get; set; }
        public string LatitudeLongitude { get; set; }
        public string Neighborhood { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
        public int IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<DiseaseAnimal> DiseaseAnimals { get; set; }
        public virtual ICollection<VaccineAnimal> VaccineAnimals { get; set; }
    }
}