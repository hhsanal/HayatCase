using Application.Features.SensorDataFeature.GetDashboardStatistic;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class DashboardController(ISender sender) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var result = await sender.Send(new GetDashboardStatisticQuery());
            return View(result.Data);
        }
    }
}
