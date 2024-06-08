namespace BettingSystem.Web.Betting.Features;

using System.Threading.Tasks;
using Application.Betting.Gamblers.Commands.Create;
using Application.Betting.Gamblers.Commands.Deposit;
using Application.Betting.Gamblers.Commands.Edit;
using Application.Betting.Gamblers.Commands.Withdraw;
using Application.Betting.Gamblers.Queries.Details;
using Application.Betting.Gamblers.Queries.GetId;
using Application.Common;
using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class GamblersController : ApiController
{
    [HttpGet]
    [Route(Id)]
    public async Task<ActionResult<GamblerDetailsResponseModel?>> Details(
        [FromRoute] GamblerDetailsQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(nameof(Id))]
    public async Task<ActionResult<GetGamblerIdResponseModel>> GetGamblerId(
        [FromRoute] GetGamblerIdQuery query)
        => await this.Send(query);

    [HttpPost]
    public async Task<ActionResult<CreateGamblerResponseModel>> Create(
        CreateGamblerCommand command)
        => await this.Send(command);

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult> Edit(
        int id, EditGamblerCommand command)
        => await this.Send(command.SetId(id));

    [HttpPut]
    [Route(Id + PathSeparator + nameof(Deposit))]
    public async Task<ActionResult> Deposit(
        int id, GamblerDepositMoneyCommand command)
        => await this.Send(command.SetId(id));

    [HttpPut]
    [Route(Id + PathSeparator + nameof(Withdraw))]
    public async Task<ActionResult> Withdraw(
        int id, GamblerWithdrawMoneyCommand command)
        => await this.Send(command.SetId(id));
}