using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("[controller]")]
public class WalletController : ApiController
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(Array.Empty<string>());
    }
}