namespace BettingSystem.Infrastructure.Betting.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Application.Betting.Gamblers;
using Application.Betting.Gamblers.Queries.Details;
using AutoMapper;
using Common.Repositories;
using Domain.Betting.Exceptions;
using Domain.Betting.Models.Gamblers;
using Domain.Betting.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;

internal class GamblerRepository : DataRepository<BettingDbContext, Gambler>,
    IGamblerDomainRepository,
    IGamblerQueryRepository
{
    private readonly IMapper mapper;

    public GamblerRepository(BettingDbContext db, IMapper mapper)
        : base(db)
        => this.mapper = mapper;

    public async Task<Gambler> FindByUser(
        string userId,
        CancellationToken cancellationToken = default)
        => await this.FindByUser(
            userId,
            user => user,
            cancellationToken);

    public async Task<int> GetGamblerId(
        string userId,
        CancellationToken cancellationToken = default)
        => await this.FindByUser(
            userId,
            user => user.Id,
            cancellationToken);

    public async Task<bool> HasBet(
        int gamblerId,
        int betId,
        CancellationToken cancellationToken = default)
        => await this
            .AllAsNoTracking()
            .Where(g => g.Id == gamblerId)
            .AnyAsync(g => g.Bets
                .Any(b => b.Id == betId), cancellationToken);

    public async Task<GamblerDetailsResponseModel?> GetDetails(
        int id,
        CancellationToken cancellationToken = default)
        => await this.mapper
            .ProjectTo<GamblerDetailsResponseModel>(this
                .AllAsNoTracking()
                .Where(g => g.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

    private async Task<T> FindByUser<T>(
        string userId,
        Expression<Func<Gambler, T>> selector,
        CancellationToken cancellationToken = default)
    {
        var gambler = await this
            .All()
            .Where(u => u.UserId == userId)
            .Select(selector)
            .FirstOrDefaultAsync(cancellationToken);

        if (EqualityComparer<T>.Default.Equals(gambler, default))
        {
            throw new InvalidGamblerException("This user is not a gambler.");
        }

        return gambler!;
    }
}