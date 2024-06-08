namespace BettingSystem.Domain.Betting.Models;

public class ModelConstants
{
    public class Bet
    {
        public const decimal MinAmountValue = decimal.One;
        public const decimal MaxAmountValue = decimal.MaxValue;
    }

    public class Gambler
    {
        public const decimal MinAmountValue = decimal.One;
        public const decimal MaxAmountValue = decimal.MaxValue;

        public const decimal MinDepositWithdrawValue = 10;
        public const decimal MaxDepositWithdrawValue = decimal.MaxValue;

        public const decimal MinBalanceValue = decimal.Zero;
        public const decimal MaxBalanceValue = decimal.MaxValue;
    }
}