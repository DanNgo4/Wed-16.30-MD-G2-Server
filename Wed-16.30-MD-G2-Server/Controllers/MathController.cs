using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Wed_16._30_MD_G2_Server.Controllers;

[Route("[controller]")]
[ApiController]
public class MathController : ControllerBase
{
    [HttpGet("sum")]
    public ActionResult<int> Get([Required] int firstNum, 
                                 [Required] int secondNum)
    {
        return Ok(firstNum + secondNum);
    }
}
