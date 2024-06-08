using Microsoft.AspNetCore.Mvc;

namespace Common.Web;

[ApiController]
[Route("api/[controller]/[action]")]
public abstract class ApiController : ControllerBase
{
    protected const string Id = "{id}";
}