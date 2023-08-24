#nullable disable

using Patas.Em.Harmonia.Domain.Constants;

namespace Patas.Em.Harmonia.Domain.Models.Entities
{
    public partial class Ngo
    {
        public Ngo() {}
        public Ngo(NgoData ngo)
        {
            Name = ngo.Name;
            Services = ngo.Services;
            Phone = ngo.Phone;
            Email = ngo.Email;
            Address = ngo.Address;
            LatitudeLongitude = ngo.LatitudeLongitude;
            Neighborhood = ngo.Neighborhood;
            Status = Constant.PENDANT;
            Created = DateTime.UtcNow;
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