#nullable disable

namespace Patas.Em.Harmonia.Infrastructure.Data.Models
{
    public partial class Ngo
    {
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