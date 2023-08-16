
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Patas.Em.Harmonia.Infrastructure.Data.Models;

namespace Patas.Em.Harmonia.Infrastructure.Data.Configuration
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.ToTable("Animal");

            builder.HasKey(e => e.IdUser);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.Age)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("age");

            builder.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");

            builder.Property(e => e.Errant).HasColumnName("errant");

            builder.Property(e => e.Gender)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("gender");

            builder.Property(e => e.IdUser).HasColumnName("id_user");

            builder.Property(e => e.LatitudeLongitude)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("latitude_longitude");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");

            builder.Property(e => e.Neighborhood)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("neighborhood");

            builder.Property(e => e.PhotoUrl)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("photo_url");

            builder.Property(e => e.Race)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("race");

            builder.Property(e => e.Species)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("species");

            builder.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");

            builder.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.Animals)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAnimalId");
        }
    }
}
