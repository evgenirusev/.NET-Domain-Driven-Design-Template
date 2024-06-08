namespace BettingSystem.Domain.Betting.Models.Matches;

using System;
using FakeItEasy;

public class StatisticsFakes
{
    public class StatisticsDummyFactory : IDummyFactory
    {
        public bool CanCreate(Type type) => type == typeof(Statistics);

        public object? Create(Type type) => new Statistics(3, 0);

        public Priority Priority => Priority.Default;
    }
}