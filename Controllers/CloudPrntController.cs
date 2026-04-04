
using Microsoft.AspNetCore.Mvc;
using CloudPrntApi.Services;

namespace CloudPrntApi.Controllers;

[ApiController]
public class CloudPrntController : ControllerBase
{
    [HttpGet("cloudprnt-setting.json")]
    public IActionResult Setting()
    {
        return Ok(new
        {
            pollingInterval = 5,
            printJobUrl = "/cloudprnt/print",
            jobReady = true
        });
    }
    
    [HttpGet("cloudprnt/print")]
    public IActionResult Print()
    {
        var data = EscPosBuilder.BuildTestReceipt();
        return File(data, "application/octet-stream");
    }

}
