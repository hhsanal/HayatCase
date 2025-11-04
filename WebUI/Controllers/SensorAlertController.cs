using Application.Features.SensorAlertFeature.GetAllAlert;
using Application.Features.SensorAlertFeature.ReadAlert;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class SensorAlertController(ISender sender) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var result = await sender.Send(new GetAllAlertQuery());
            return View(result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> AcknowledgeAlert(Guid alertId)
        {
            var result = await sender.Send(new ReadAlertCommand(alertId));
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            return BadRequest(result.Message);
        }
    }
}