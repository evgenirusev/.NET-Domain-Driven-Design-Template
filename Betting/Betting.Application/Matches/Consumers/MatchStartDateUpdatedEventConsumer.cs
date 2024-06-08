namespace BettingSystem.Application.Betting.Matches.Consumers;

using System.Threading.Tasks;
using Domain.Betting.Repositories;
using Domain.Common.Events.Matches;
using MassTransit;

public class MatchStartDateUpdatedEventConsumer : IConsumer<MatchStartDateUpdatedEvent>
{
    private readonly IMatchDomainRepository matchRepository;

    public MatchStartDateUpdatedEventConsumer(IMatchDomainRepository matchRepository)
        => this.matchRepository = matchRepository;

    public async Task Consume(ConsumeContext<MatchStartDateUpdatedEvent> context)
    {
        var eventMessage = context.Message;

        var match = await this.matchRepository.Find(eventMessage.Id);

        match!.UpdateStartDate(eventMessage.StartDate);

        await this.matchRepository.Save(match);
    }
}