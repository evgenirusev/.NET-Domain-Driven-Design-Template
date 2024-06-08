namespace BettingSystem.Domain.Betting.Models.Bets;

using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Common.Models;
using FakeItEasy;

using static ModelConstants.Bet;
using static Matches.MatchFakes.Data;

public class BetFakes
{
    public class BetDummyFactory : IDummyFactory
    {
        public bool CanCreate(Type type) => type == typeof(Bet);

        public object? Create(Type type) => Data.GetBet();

        public Priority Priority => Priority.Default;
    }

    public static class Data
    {
        public static IEnumerable<Bet> GetBets(int count = 10)
            => Enumerable
                .Range(1, count)
                .Select(i => GetBet(i))
                .Concat(Enumerable
                    .Range(count + 1, count * 2)
                    .Select(i => GetBet(i)))
                .ToList();

        public static Bet GetBet(int id = 1, bool isProfitable = false)
            => new Faker<Bet>()
                .CustomInstantiator(f => new Bet(
                    GetMatch(id),
                    f.Random.Decimal(MinAmountValue),
                    f.PickRandomParam(
                        Prediction.Away,
                        Prediction.Draw,
                        Prediction.Home),
                    isProfitable))
                .Generate()
                .SetId(id);
    }
}