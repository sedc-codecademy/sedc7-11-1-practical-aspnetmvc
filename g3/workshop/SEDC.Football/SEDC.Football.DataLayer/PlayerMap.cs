using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEDC.Football.Domain.Models;

namespace SEDC.Football.DataLayer
{
    public class PlayerMap : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder
                .ToTable(nameof(Player))
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Age)
                .IsRequired();

            builder
                .Property(p => p.FullName)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(p => p.SquadNumber)
                .IsRequired();

            builder
                .Property(p => p.Position)
                .IsRequired();

            builder
                .HasOne(p => p.Team);
            
        }
    }
}
