using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Patas.Em.Harmonia.Infrastructure.Data.Models;

namespace Patas.Em.Harmonia.Infrastructure.Data.Configuration
{
    public class NgoConfiguration : IEntityTypeConfiguration<Ngo>
    {
        public void Configure(EntityTypeBuilder<Ngo> builder)
        {
            builder.ToTable("NGO");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");

            builder.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");

            builder.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");

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

            builder.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone");

            builder.Property(e => e.Services)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("services");

            builder.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");
        }
    }
}
