namespace BettingSystem.Domain.Betting.Models.Bets;

using Common.Models;

public class Prediction : Enumeration
{
    public static readonly Prediction Draw = new(0, nameof(Draw));
    public static readonly Prediction Home = new(1, nameof(Home));
    public static readonly Prediction Away = new(2, nameof(Away));

    private Prediction(int value)
        : this(value, FromValue<Prediction>(value).Name)
    {
    }

    private Prediction(int value, string name)
        : base(value, name)
    {
    }
}