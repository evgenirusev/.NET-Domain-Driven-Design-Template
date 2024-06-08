namespace BettingSystem.Domain.Betting.Specifications.Gamblers;

using System;
using System.Linq.Expressions;
using Common;
using Models.Gamblers;

public class GamblerByIdSpecification : Specification<Gambler>
{
    private readonly int? id;

    public GamblerByIdSpecification(int? id) => this.id = id;

    protected override bool Include => this.id != null;

    public override Expression<Func<Gambler, bool>> ToExpression()
        => gambler => gambler.Id == this.id;
}