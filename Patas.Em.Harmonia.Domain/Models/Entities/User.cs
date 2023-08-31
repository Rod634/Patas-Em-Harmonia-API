#nullable disable

using Patas;
using Patas.Em.Harmonia.Domain.Constants;
using Patas.Em.Harmonia.Domain.Models.DTO;

namespace Patas.Em.Harmonia.Domain.Models.Entities
{
    public partial class User
    {
        public User()
        {
            Animals = new HashSet<Animal>();
        }

        public static explicit operator User(UserDto newUser)
        {
            return new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = newUser.Name,
                Email = newUser.Email,
                Phone = newUser.Phone,
                HasPets = newUser.HasPets,
                NgoId = newUser.NgoId,
                AditionalInfo = newUser.AditionalInfo,
                Created = DateTime.UtcNow,
                Status = Constant.ACTIVE,
                Passwrd = "zap"
            };
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Passwrd { get; set; }
        public bool HasPets { get; set; }
        public string NgoId { get; set; }
        public string AditionalInfo { get; set; }
        public string Status { get; set; }
        public DateTime? Created { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}