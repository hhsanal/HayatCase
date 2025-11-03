using System.ComponentModel;

namespace Domain.Enums;

public enum SensorUnit
{
    [Description("°C - Celsius")]
    Celsius,

    [Description("°F - Fahrenheit")]
    Fahrenheit,

    [Description("Pa - Pascal")]
    Pascal,

    [Description("bar - Bar")]
    Bar,

    [Description("ppm - Parts per million")]
    Ppm,

    [Description("% - Percentage")]
    Percentage,

    [Description("V - Volt")]
    Volt,

    [Description("A - Ampere")]
    Ampere
}
