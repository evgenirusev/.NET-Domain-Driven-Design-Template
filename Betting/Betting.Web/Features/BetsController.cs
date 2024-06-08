namespace BettingSystem.Web.Betting.Features;

using System.Threading.Tasks;
using Application.Betting.Bets.Commands.Close;
using Application.Betting.Bets.Commands.Create;
using Application.Betting.Bets.Commands.MakeProfitable;
using Application.Betting.Bets.Queries.Details;
using Application.Betting.Bets.Queries.Mine;
using Application.Betting.Bets.Queries.Search;
using Common;
using Common.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class BetsController : ApiController
{
    [HttpGet]
    public async Task<ActionResult<SearchBetsResponseModel>> Search(
        [FromQuery] SearchBetsQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(nameof(Mine))]
    public async Task<ActionResult<MineBetsResponseModel>> Mine(
        [FromQuery] MineBetsQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(Id)]
    public async Task<ActionResult<BetDetailsResponseModel?>> Details(
        [FromRoute] BetDetailsQuery query)
        => await this.Send(query);

    [HttpPost]
    public async Task<ActionResult<CreateBetResponseModel>> Create(
        CreateBetCommand command)
        => await this.Send(command);

    [HttpPut]
    [Route(Id)]
    [AuthorizeAdministrator]
    public async Task<ActionResult> MakeProfitable(
        [FromRoute] MakeBetProfitableCommand command)
        => await this.Send(command);

    [HttpDelete]
    [Route(Id)]
    public async Task<ActionResult> Close(
        [FromRoute] CloseBetCommand command)
        => await this.Send(command);
}