using Microsoft.Extensions.Logging;

namespace TheUnitVerseSimple;

// Gets the main MAUI program class to configure and build the app
public static class MauiProgram
{
    // Creates and configures the MAUI app
    public static MauiApp CreateMauiApp()
    {
        // Creates a new app builder
        var builder = MauiApp.CreateBuilder();

        // Uses the App class as the main application entry
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                // Adds the regular and semibold OpenSans fonts
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        // Adds debug logging when in debug mode
        builder.Logging.AddDebug();
#endif

        // Builds and returns the configured MAUI app
        return builder.Build();
    }
}
