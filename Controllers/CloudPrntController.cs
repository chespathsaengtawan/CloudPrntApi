
using Microsoft.AspNetCore.Mvc;
using CloudPrntApi.Services;

namespace CloudPrntApi.Controllers;

[ApiController]
public class CloudPrntController : ControllerBase
{
    private readonly ILogger<CloudPrntController> _logger;
    public CloudPrntController(ILogger<CloudPrntController> logger)
    {
        _logger = logger;
    }
    [HttpGet("cloudprnt-setting.json")]
    public IActionResult Setting()
    {

        _logger.LogInformation("Received request for cloudprnt-setting.json");
        return Ok(new
        {
            pollingInterval = 10,
            printJobUrl = "/cloudprnt/print",
            jobReady = true
        });
    }
    
    [HttpGet("cloudprnt/print")]
    public IActionResult Print()
    {
        _logger.LogInformation("Received request for cloudprnt/print");
        var data = EscPosBuilder.BuildTestReceipt();
        return File(data, "application/octet-stream");
    }

    [HttpGet("cloudprnt/status")]
    public IActionResult Status()
    {
        _logger.LogInformation("Received request for cloudprnt/status");
        return Ok(new
        {
            status = "ok"
        });
    }

}
