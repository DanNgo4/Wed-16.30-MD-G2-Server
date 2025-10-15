using Microsoft.AspNetCore.Mvc;

namespace Wed_16._30_MD_G2_Server.Controllers;

[Route("[controller]")]
[ApiController]
public class HelloController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;

    public HelloController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    [HttpGet]
    public ActionResult<string> Get()
    {
        return Ok($"Hello from {_environment.EnvironmentName} environment!");
    }
}
