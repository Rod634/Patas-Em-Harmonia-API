#nullable disable

namespace Patas.Em.Harmonia.Infrastructure.Data.Models
{
    public partial class User
    {
        public User()
        {
            Animals = new HashSet<Animal>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Passwrd { get; set; }
        public string HasPets { get; set; }
        public string NgoName { get; set; }
        public string AditionalInfo { get; set; }
        public string Status { get; set; }
        public DateTime? Created { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}