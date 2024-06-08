namespace BettingSystem.Infrastructure.Betting.Configurations;

using Domain.Betting.Models.Gamblers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Common.Models.ModelConstants.Common;

internal class GamblerConfiguration : IEntityTypeConfiguration<Gambler>
{
    public void Configure(EntityTypeBuilder<Gambler> builder)
    {
        builder
            .HasKey(g => g.Id);

        builder
            .Property(g => g.Name)
            .HasMaxLength(MaxNameLength)
            .IsRequired();

        builder
            .Property(g => g.UserId)
            .IsRequired();

        builder
            .Property(g => g.Balance)
            .HasPrecision(19, 4)
            .IsRequired();

        builder
            .HasMany(g => g.Bets)
            .WithOne()
            .IsRequired()
            .Metadata
            .PrincipalToDependent!
            .SetField("bets");
    }
}