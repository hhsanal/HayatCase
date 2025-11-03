using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class DashboardSensorDataDto
    {
        public int TotalDataCount { get; set; }
        public decimal AverageReadingTemperatureValue { get; set; }
        public decimal AverageReadingMoistureValue { get; set; }
        public decimal AverageLatency { get; set; }
        public decimal MaxTemperatureValue { get; set; }
        public decimal MinTemperatureValue { get; set; }
        public decimal MaxMoistureValue { get; set; }
        public decimal MinMoistureValue { get; set; }
        public int thresholdExceededCount { get; set; }
    }
}
