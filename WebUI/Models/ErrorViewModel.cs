using Application.Features.FactorySensorFeature.GetFactorySensorById;
using Application.Features.SensorDataFeature.GetSensorDataListBySensorId;

namespace WebUI.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class FactorySensorDataListModel
    {
        public FactorySensorByIdResponse sensor { get; set; }
        public List<GetSensorDataListBySensorIdResponse> data { get; set; }
    }
}
