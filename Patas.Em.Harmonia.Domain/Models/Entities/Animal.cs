#nullable disable

using Patas;
using Patas.Em.Harmonia.Domain.Constants;

namespace Patas.Em.Harmonia.Domain.Models.Entities
{
    public partial class Animal
    {
        public Animal()
        {
            DiseaseAnimals = new HashSet<DiseaseAnimal>();
            VaccineAnimals = new HashSet<VaccineAnimal>();
        }

        public Animal(AnimalData animal)
        {
            Name = animal.Name;
            Age = animal.Age;
            Race = animal.Race;
            Species = animal.Species;
            Gender = animal.Gender;
            Errant = animal.Errant;
            PhotoUrl = animal.PhotoUrl;
            LatitudeLongitude = animal.LatitudeLongitude;
            Neighborhood = animal.Neighborhood;
            Status = Constant.ACTIVE;
            Created = DateTime.UtcNow;
            IdUser = animal.IdUser;
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