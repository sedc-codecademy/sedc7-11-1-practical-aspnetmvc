using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEDC.Football.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Football.DataLayer.Maps
{
    public class TeamMap : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder
                .ToTable(nameof(Team))
                .HasKey(p => p .Id);

            builder
                .Property(p => p.Couch)
                .HasMaxLength(100);

            builder
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
