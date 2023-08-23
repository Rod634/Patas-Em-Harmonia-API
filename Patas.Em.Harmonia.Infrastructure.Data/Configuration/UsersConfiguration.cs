
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Patas.Em.Harmonia.Domain.Models;

namespace Patas.Em.Harmonia.Infrastructure.Data.Configuration
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.AditionalInfo)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("aditional_info");

            builder.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");

            builder.Property(e => e.HasPets)
                .IsRequired()
                .HasColumnName("has_pets");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");

            builder.Property(e => e.NgoName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NGO_name");

            builder.Property(e => e.Passwrd)
                .IsRequired()
                .HasMaxLength(555)
                .IsUnicode(false)
                .HasColumnName("passwrd");

            builder.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone");

            builder.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");
        }
    }
}
