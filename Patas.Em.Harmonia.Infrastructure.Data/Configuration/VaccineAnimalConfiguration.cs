
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Patas.Em.Harmonia.Infrastructure.Data.Models;

namespace Patas.Em.Harmonia.Infrastructure.Data.Configuration
{
    public class VaccineAnimalConfiguration : IEntityTypeConfiguration<VaccineAnimal>
    {
        public void Configure(EntityTypeBuilder<VaccineAnimal> builder)
        {
            builder.ToTable("Vaccine_animal");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.DtVaccine)
                .HasColumnType("datetime")
                .HasColumnName("dt_vaccine");

            builder.Property(e => e.IdAnimal).HasColumnName("id_animal");

            builder.Property(e => e.IdVaccine).HasColumnName("id_vaccine");

            builder.HasOne(d => d.IdAnimalNavigation)
                .WithMany(p => p.VaccineAnimals)
                .HasForeignKey(d => d.IdAnimal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AnimalVaccineId");

            builder.HasOne(d => d.IdVaccineNavigation)
                .WithMany(p => p.VaccineAnimals)
                .HasForeignKey(d => d.IdVaccine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VaccinelId");
        }
    }
}
