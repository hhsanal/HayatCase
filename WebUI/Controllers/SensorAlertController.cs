using Application.Features.SensorAlertFeature.GetAllAlert;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class SensorAlertController(ISender sender) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var result = await sender.Send(new GetAllAlertQuery());
            return View(result.Data);
        }
    }
}
