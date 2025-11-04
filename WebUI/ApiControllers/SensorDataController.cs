using Application.Features.SensorDataFeature.AddSensorData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ApiControllers;

[Route("api/[controller]")]
[ApiController]
public class SensorDataController(ISender sender) : ControllerBase
{

    public async Task<IActionResult> UpdateSensorData(AddSensorDataCommand command)
    {
       var result = await sender.Send(command);
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }
        return Ok(result.Message);
    }
}
