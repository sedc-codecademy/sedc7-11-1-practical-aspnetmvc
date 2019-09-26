using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEDC.Football.Domain.Models;
using System;

namespace SEDC.Football.DataLayer.Maps
{
    public class MatchMap : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder
                .ToTable(nameof(Match))
                .HasKey(p => p.Id);

            builder
                .HasOne(p => p.HomeTeam);

            builder
                .HasOne(p => p.AwayTeam);

            builder
                .Property(p => p.AwayTeamId)
                .IsRequired();

            builder
                .Property(p => p.HomeTeamId)
                .IsRequired();

            builder
                .Property(p => p.HomeTeamGoals)
                .HasDefaultValue(0);

            builder
                .Property(p => p.AwayTeamGoals)
                .HasDefaultValue(0);
        }
    }
}
