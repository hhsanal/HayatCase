using SimulationWorker.Models;
using System.Net.Http.Json;

namespace SimulationWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Random _random = new Random();

        public Worker(ILogger<Worker> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(10000, stoppingToken);
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var randomSensor = sensorInfos[_random.Next(sensorInfos.Count)];

                    var randomValue = randomSensor.MinValue + (decimal)(_random.NextDouble() * (double)(randomSensor.MaxValue - randomSensor.MinValue));

                    var sensorData = new SensorData
                    {
                        SensorId = randomSensor.SensorId,
                        Value = Math.Round(randomValue, 2),
                        TimeStamp = DateTimeOffset.Now
                    };

                    var httpClient = _httpClientFactory.CreateClient();
                    var response = await httpClient.PostAsJsonAsync("https://localhost:44392/api/SensorData", sensorData, stoppingToken);

                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while sending sensor data");
                }

                // 5 saniye bekle
                await Task.Delay(5000, stoppingToken);
            }
        }

        public static List<SensorInfo> sensorInfos = new List<SensorInfo>
            {
                new SensorInfo { SensorId = Guid.Parse("18B561C0-782B-423F-A06A-0E82BB860E23"), MinValue = 10, MaxValue = 40 },
                new SensorInfo { SensorId = Guid.Parse("09EA46D1-BEC1-422A-923B-406DCCB70261"), MinValue = 0, MaxValue = 100 },
                new SensorInfo { SensorId = Guid.Parse("2FED24EF-F280-4CAE-AF1E-942444ED2686"), MinValue = 0, MaxValue = 60 },
                new SensorInfo { SensorId = Guid.Parse("5EB987C3-4498-46DF-A814-961933ABB70C"), MinValue = 50, MaxValue = 150 },
                new SensorInfo { SensorId = Guid.Parse("9F8F018E-20ED-49CB-A706-F895BBB893AF"), MinValue = 150, MaxValue = 200 },
                new SensorInfo { SensorId = Guid.Parse("4597A6B9-C079-4CBF-93BE-FF7997CBBCFA"), MinValue = 20, MaxValue = 100 },
            };
    }
}
