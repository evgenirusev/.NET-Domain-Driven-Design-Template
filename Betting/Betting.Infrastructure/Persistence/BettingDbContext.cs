namespace BettingSystem.Infrastructure.Betting.Persistence;

using System.Reflection;
using Domain.Betting.Models.Bets;
using Domain.Betting.Models.Gamblers;
using Domain.Betting.Models.Matches;
using Microsoft.EntityFrameworkCore;

internal class BettingDbContext : DbContext
{
    public BettingDbContext(DbContextOptions<BettingDbContext> options)
        : base(options)
    {
    }

    public DbSet<Bet> Bets { get; set; } = default!;

    public DbSet<Match> Matches { get; set; } = default!;

    public DbSet<Gambler> Gamblers { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}