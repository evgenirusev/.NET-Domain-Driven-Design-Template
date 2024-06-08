namespace BettingSystem.Domain.Betting.Models.Matches;

using System;
using Bogus;
using Common.Models;
using FakeItEasy;

public class MatchFakes
{
    public class MatchDummyFactory : IDummyFactory
    {
        public bool CanCreate(Type type) => type == typeof(Match);

        public object? Create(Type type) => Data.GetMatch();

        public Priority Priority => Priority.Default;
    }

    public static class Data
    {
        public static Match GetMatch(int id = 1)
            => new Faker<Match>()
                .CustomInstantiator(_ => new Match(
                    DateTime.Today,
                    A.Dummy<Statistics>(),
                    Status.FirstHalf))
                .Generate()
                .SetId(id);
    }
}