
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Patas.Em.Harmonia.Infrastructure.Data.Models;

namespace Patas.Em.Harmonia.Infrastructure.Data.Configuration
{
    public class DiseaseAnimalConfiguration : IEntityTypeConfiguration<DiseaseAnimal>
    {
        public void Configure(EntityTypeBuilder<DiseaseAnimal> builder)
        {
            builder.ToTable("Disease_animal");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            builder.Property(e => e.IdAnimal).HasColumnName("id_animal");

            builder.Property(e => e.IdDisease).HasColumnName("id_disease");

            builder.Property(e => e.IdStatus).HasColumnName("id_status");

            builder.HasOne(d => d.IdAnimalNavigation)
                .WithMany(p => p.DiseaseAnimals)
                .HasForeignKey(d => d.IdAnimal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AnimaDiseaselId");

            builder.HasOne(d => d.IdDiseaseNavigation)
                .WithMany(p => p.DiseaseAnimals)
                .HasForeignKey(d => d.IdDisease)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiseaselId");

            builder.HasOne(d => d.IdStatusNavigation)
                .WithMany(p => p.DiseaseAnimals)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StatusDiseaselId");
        }
    }
}
