using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace Wed_16._30_MD_G2_Server.Controllers;

[Route("[controller]")]
[ApiController]
public class MathController : ControllerBase
{
    private readonly ILogger<MathController> _logger;
   

    public MathController(ILogger<MathController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet("sum")]
    public ActionResult<int> Get([Required] int firstNum, 
                                 [Required] int secondNum)
    {
        int result = firstNum + secondNum;
        
        _logger.LogInformation($"[LOG STREAM] SUM endpoint called: {firstNum} + {secondNum} = {result}");
        
        
        return Ok(result);
    }

    [HttpGet("health")]
    public ActionResult<string> Health()
    { 
        _logger.LogInformation($"[HEALTH CHECK] /math/health hit at {DateTime.UtcNow}");
        
        return Ok("Service is healthy");                                                                                                                          
    }    
}
