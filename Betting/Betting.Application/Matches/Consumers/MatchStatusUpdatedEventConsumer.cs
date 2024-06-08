namespace BettingSystem.Application.Betting.Matches.Consumers;

using System.Threading.Tasks;
using Domain.Betting.Models.Matches;
using Domain.Betting.Repositories;
using Domain.Common.Events.Matches;
using Domain.Common.Models;
using MassTransit;

public class MatchStatusUpdatedEventConsumer : IConsumer<MatchStatusUpdatedEvent>
{
    private readonly IMatchDomainRepository matchRepository;

    public MatchStatusUpdatedEventConsumer(IMatchDomainRepository matchRepository)
        => this.matchRepository = matchRepository;

    public async Task Consume(ConsumeContext<MatchStatusUpdatedEvent> context)
    {
        var eventMessage = context.Message;

        var match = await this.matchRepository.Find(eventMessage.Id);

        match!.UpdateStatus(Enumeration.FromValue<Status>(
            eventMessage.Status));

        await this.matchRepository.Save(match);
    }
}