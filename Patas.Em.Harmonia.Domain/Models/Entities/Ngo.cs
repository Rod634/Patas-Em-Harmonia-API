#nullable disable

using Patas.Em.Harmonia.Domain.Constants;
using Patas.Em.Harmonia.Domain.Models.DTO;

namespace Patas.Em.Harmonia.Domain.Models.Entities
{
    public partial class Ngo
    {
        public Ngo() { }
        
        public static explicit operator Ngo(NgoDto ngo)
        {
            return new()
            {
                Name = ngo.Name,
                Services = ngo.Services,
                Phone = ngo.Phone,
                Email = ngo.Email,
                Address = ngo.Address,
                LatitudeLongitude = ngo.LatitudeLongitude,
                Neighborhood = ngo.Neighborhood,
                Status = Constant.PENDANT,
                Created = DateTime.UtcNow
            };
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Services { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string LatitudeLongitude { get; set; }
        public string Neighborhood { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
    }
}