using Microsoft.AspNetCore.Mvc;

namespace WebUI.ApiControllers;

[Route("api/[controller]")]
[ApiController]
public class SensorDataController : ControllerBase
{

    public async Task<IActionResult> UpdateSensorData()
    {
        return Ok();
    }
}
