﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Patas.Em.Harmonia.Infrastructure.Data.Models;

namespace Patas.Em.Harmonia.Infrastructure.Data.Configuration
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Status");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        }
    }
}
