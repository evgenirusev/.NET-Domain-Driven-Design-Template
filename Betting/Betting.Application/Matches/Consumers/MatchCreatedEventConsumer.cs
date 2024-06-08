namespace BettingSystem.Application.Betting.Matches.Consumers;

using System.Threading.Tasks;
using Domain.Betting.Factories.Matches;
using Domain.Betting.Repositories;
using Domain.Common.Events.Matches;
using MassTransit;

public class MatchCreatedEventConsumer : IConsumer<MatchCreatedEvent>
{
    private readonly IMatchFactory matchFactory;
    private readonly IMatchDomainRepository matchRepository;

    public MatchCreatedEventConsumer(
        IMatchFactory matchFactory,
        IMatchDomainRepository matchRepository)
    {
        this.matchFactory = matchFactory;
        this.matchRepository = matchRepository;
    }

    public async Task Consume(ConsumeContext<MatchCreatedEvent> context)
    {
        var match = this.matchFactory.Build(context.Message.StartDate);

        await this.matchRepository.Save(match);
    }
}