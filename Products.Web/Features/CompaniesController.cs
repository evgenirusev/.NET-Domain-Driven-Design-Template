using Common.Web;

namespace BettingSystem.Web.Betting.Features;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class CompaniesController : ApiController
{
    [HttpGet]
    public async Task<ActionResult> Test()
    {
        return Ok();
    }
}