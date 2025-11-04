using Application.Services;
using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.Services;

public class SeedDataGenerateService : ISeedDataGenerateService
{
    public List<FactorySensor> GenerateFactorySensorsAsync()
    {
        return new List<FactorySensor>
        {
            new FactorySensor { Id = Guid.Parse("18B561C0-782B-423F-A06A-0E82BB860E23"),Code = "HUM-003", Description = "Su hattı Nem sensörü", Unit = SensorUnit.Percentage, IsActive=true,ThresholdValue=56 , Location = "Su Giriş Vanası" },
            new FactorySensor { Id = Guid.Parse("09EA46D1-BEC1-422A-923B-406DCCB70261"),Code = "TEMP-003", Description = "Hammadde karıştırıcı içi sıcaklık sensörü", Unit = SensorUnit.Celsius, IsActive=true,ThresholdValue=60 , Location = "Karışım Ünitesi" },
            new FactorySensor { Id = Guid.Parse("2FED24EF-F280-4CAE-AF1E-942444ED2686"),Code = "HUM-001", Description = "Nem sensörü - Kompresör çıkışı", Unit = SensorUnit.Percentage, IsActive=true,ThresholdValue=40 , Location = "Kompresör Odası" },
            new FactorySensor { Id = Guid.Parse("5EB987C3-4498-46DF-A814-961933ABB70C"),Code = "TEMP-002", Description = "Soğutma hattı giriş sıcaklık sensörü", Unit = SensorUnit.Celsius, IsActive=true,ThresholdValue=30 , Location = "Hat B Giriş" },
            new FactorySensor { Id = Guid.Parse("9F8F018E-20ED-49CB-A706-F895BBB893AF"),Code = "TEMP-001", Description = "Fırın Bölgesi sıcaklık sensörü", Unit = SensorUnit.Celsius, IsActive=true,ThresholdValue=130 , Location = "Fırın Hattı A" },
            new FactorySensor { Id = Guid.Parse("4597A6B9-C079-4CBF-93BE-FF7997CBBCFA"),Code = "HUM-002", Description = "Hat içi Nem ölçer", Unit = SensorUnit.Percentage, IsActive=true,ThresholdValue=68 , Location = "Hat C Orta Nokta" },
        };
    }
}
