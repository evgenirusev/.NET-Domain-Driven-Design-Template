namespace BettingSystem.Domain.Betting.Specifications.Bets;

using System;
using System.Linq.Expressions;
using Common;
using Models.Bets;

public class BetOnlyProfitableSpecification : Specification<Bet>
{
    private readonly bool? onlyProfitable;

    public BetOnlyProfitableSpecification(bool? onlyProfitable)
        => this.onlyProfitable = onlyProfitable;

    protected override bool Include => this.onlyProfitable != null;

    public override Expression<Func<Bet, bool>> ToExpression()
        => bet => bet.IsProfitable == this.onlyProfitable!;
}