using Application.Features.FactorySensorFeature.GetFactorySensorById;
using Application.Features.FactorySensorFeature.GetFactorySensorList;
using Application.Features.SensorDataFeature.GetAllSensorData;
using Application.Features.SensorDataFeature.GetSensorDataListBySensorId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class FactorySensorController(ISender sender) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var result = await sender.Send(new GetFactorySensorListQuery());
            if (result.Success)
                return View(result.Data);
            return View();
        }


        public async Task<IActionResult> DataList(Guid SensorId)
        {
            var sensor = await sender.Send(new GetFactorySensorByIdQuery(SensorId));
            var result = await sender.Send(new GetSensorDataListBySensorIdQuery(SensorId));

            FactorySensorDataListModel response = new()
            {
                data = result.Data,
                sensor = sensor.Data
            };
            if (result.Success)
                return View(response);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AllData()
        {
            var result = await sender.Send(new GetAllSensorDataQuery());
            if (result.Success)
                return View(result.Data);
            return View();
        }
    }
}
