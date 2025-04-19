namespace TheUnitVerseSimple;

public static class UnitConverterLogic
{
    public static Dictionary<string, (string[], Func<double, string, string, double>)> GetConversionMap()
    {
        return new()
        {
            ["Length"] = (new[] { "Meters", "Kilometers", "Feet", "Miles" }, ConvertLength),
            ["Temperature"] = (new[] { "Celsius", "Fahrenheit", "Kelvin" }, ConvertTemperature),
            ["Time"] = (new[] { "Seconds", "Minutes", "Hours" }, ConvertTime),
            ["Weight/Mass"] = (new[] { "Grams", "Kilograms", "Pounds", "Ounces" }, ConvertWeight),
            ["Speed"] = (new[] { "Meters/Second", "Kilometers/Hour", "Miles/Hour" }, ConvertSpeed),
            ["Volume"] = (new[] { "Liters", "Milliliters", "Gallons", "Cups" }, ConvertVolume),
            ["Area"] = (new[] { "Square Meters", "Square Feet", "Acres", "Hectares" }, ConvertArea),
            ["Pressure"] = (new[] { "Pascals", "Bar", "PSI", "Atmospheres" }, ConvertPressure),
            ["Energy"] = (new[] { "Joules", "Calories", "Kilowatt-Hours" }, ConvertEnergy),
            ["Data Storage"] = (new[] { "Bytes", "Kilobytes", "Megabytes", "Gigabytes", "Terabytes" }, ConvertDataStorage),
            ["Fuel Consumption"] = (new[] { "MPG", "L/100km" }, ConvertFuelConsumption),
        };
    }

    static double ConvertLength(double value, string from, string to)
    {
        var meters = from switch
        {
            "Meters" => value,
            "Kilometers" => value * 1000,
            "Feet" => value * 0.3048,
            "Miles" => value * 1609.34,
            _ => value
        };

        return to switch
        {
            "Meters" => meters,
            "Kilometers" => meters / 1000,
            "Feet" => meters / 0.3048,
            "Miles" => meters / 1609.34,
            _ => meters
        };
    }

    static double ConvertTemperature(double value, string from, string to)
    {
        if (from == to) return value;
        double c = from switch
        {
            "Celsius" => value,
            "Fahrenheit" => (value - 32) * 5 / 9,
            "Kelvin" => value - 273.15,
            _ => value
        };

        return to switch
        {
            "Celsius" => c,
            "Fahrenheit" => c * 9 / 5 + 32,
            "Kelvin" => c + 273.15,
            _ => c
        };
    }

    static double ConvertTime(double value, string from, string to)
    {
        var seconds = from switch
        {
            "Seconds" => value,
            "Minutes" => value * 60,
            "Hours" => value * 3600,
            _ => value
        };

        return to switch
        {
            "Seconds" => seconds,
            "Minutes" => seconds / 60,
            "Hours" => seconds / 3600,
            _ => seconds
        };
    }

    static double ConvertWeight(double value, string from, string to)
    {
        var grams = from switch
        {
            "Grams" => value,
            "Kilograms" => value * 1000,
            "Pounds" => value * 453.592,
            "Ounces" => value * 28.3495,
            _ => value
        };

        return to switch
        {
            "Grams" => grams,
            "Kilograms" => grams / 1000,
            "Pounds" => grams / 453.592,
            "Ounces" => grams / 28.3495,
            _ => grams
        };
    }

    static double ConvertSpeed(double value, string from, string to)
    {
        var mps = from switch
        {
            "Meters/Second" => value,
            "Kilometers/Hour" => value / 3.6,
            "Miles/Hour" => value * 0.44704,
            _ => value
        };

        return to switch
        {
            "Meters/Second" => mps,
            "Kilometers/Hour" => mps * 3.6,
            "Miles/Hour" => mps / 0.44704,
            _ => mps
        };
    }

    static double ConvertVolume(double value, string from, string to)
    {
        var liters = from switch
        {
            "Liters" => value,
            "Milliliters" => value / 1000,
            "Gallons" => value * 3.78541,
            "Cups" => value * 0.236588,
            _ => value
        };

        return to switch
        {
            "Liters" => liters,
            "Milliliters" => liters * 1000,
            "Gallons" => liters / 3.78541,
            "Cups" => liters / 0.236588,
            _ => liters
        };
    }

    static double ConvertArea(double value, string from, string to)
    {
        var sqm = from switch
        {
            "Square Meters" => value,
            "Square Feet" => value * 0.092903,
            "Acres" => value * 4046.86,
            "Hectares" => value * 10000,
            _ => value
        };

        return to switch
        {
            "Square Meters" => sqm,
            "Square Feet" => sqm / 0.092903,
            "Acres" => sqm / 4046.86,
            "Hectares" => sqm / 10000,
            _ => sqm
        };
    }

    static double ConvertPressure(double value, string from, string to)
    {
        var pascals = from switch
        {
            "Pascals" => value,
            "Bar" => value * 100000,
            "PSI" => value * 6894.76,
            "Atmospheres" => value * 101325,
            _ => value
        };

        return to switch
        {
            "Pascals" => pascals,
            "Bar" => pascals / 100000,
            "PSI" => pascals / 6894.76,
            "Atmospheres" => pascals / 101325,
            _ => pascals
        };
    }

    static double ConvertEnergy(double value, string from, string to)
    {
        var joules = from switch
        {
            "Joules" => value,
            "Calories" => value * 4.184,
            "Kilowatt-Hours" => value * 3600000,
            _ => value
        };

        return to switch
        {
            "Joules" => joules,
            "Calories" => joules / 4.184,
            "Kilowatt-Hours" => joules / 3600000,
            _ => joules
        };
    }

    static double ConvertDataStorage(double value, string from, string to)
    {
        var bytes = from switch
        {
            "Bytes" => value,
            "Kilobytes" => value * 1024,
            "Megabytes" => value * 1024 * 1024,
            "Gigabytes" => value * 1024 * 1024 * 1024,
            "Terabytes" => value * 1024 * 1024 * 1024 * 1024,
            _ => value
        };

        return to switch
        {
            "Bytes" => bytes,
            "Kilobytes" => bytes / 1024,
            "Megabytes" => bytes / (1024 * 1024),
            "Gigabytes" => bytes / (1024 * 1024 * 1024),
            "Terabytes" => bytes / (1024L * 1024 * 1024 * 1024),
            _ => bytes
        };
    }

    static double ConvertFuelConsumption(double value, string from, string to)
    {
        return (from, to) switch
        {
            ("MPG", "L/100km") => 235.215 / value,
            ("L/100km", "MPG") => 235.215 / value,
            _ => value
        };
    }
}
