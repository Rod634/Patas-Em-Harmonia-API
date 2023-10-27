namespace Patas.Em.Harmonia.Domain.Models.DTO
{
    public class CreateAnimalDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Race { get; set; }
        public string Species { get; set; }
        public string Gender { get; set; }
        public bool Errant { get; set; }
        public string? PhotoUrl { get; set; }
        public string LatitudeLongitude { get; set; }
        public string Neighborhood { get; set; }
        public string? Status { get; set; }
        public string IdUser { get; set; }
        public string NgoId { get; set; }
        public List<DiseaseDto>? Disease { get; set; }
        public List<VaccineDto>? Vaccine { get; set; }

    }
}
