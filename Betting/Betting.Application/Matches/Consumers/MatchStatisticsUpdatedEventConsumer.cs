namespace BettingSystem.Application.Betting.Matches.Consumers;

using System.Threading.Tasks;
using Domain.Betting.Repositories;
using Domain.Common.Events.Matches;
using MassTransit;

public class MatchStatisticsUpdatedEventConsumer : IConsumer<MatchStatisticsUpdatedEvent>
{
    private readonly IMatchDomainRepository matchRepository;

    public MatchStatisticsUpdatedEventConsumer(IMatchDomainRepository matchRepository)
        => this.matchRepository = matchRepository;

    public async Task Consume(ConsumeContext<MatchStatisticsUpdatedEvent> context)
    {
        var eventMessage = context.Message;

        var match = await this.matchRepository.Find(eventMessage.Id);

        match!
            .Statistics
            .UpdateHomeScore(eventMessage.HomeScore)
            .UpdateAwayScore(eventMessage.AwayScore)
            .UpdateHalfTimeScore(
                eventMessage.HalfTimeHomeScore,
                eventMessage.HalfTimeAwayScore);

        await this.matchRepository.Save(match);
    }
}