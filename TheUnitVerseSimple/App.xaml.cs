using System;
using System.IO;
using Microsoft.Maui.Controls;

namespace TheUnitVerseSimple;

// Gets the main application class
public partial class App : Application
{
    // Gets the shared Database instance
    public static Database Database;

    // Gets the constructor for the app
    public App()
    {
        // Initializes the app components
        InitializeComponent();

        // Gets the path to store the database
        string dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "unitverse.db3");

        // Creates the database instance using the path
        Database = new Database(dbPath);

        // Sets the first page of the app to be the unit converter page inside a navigation page
        MainPage = new NavigationPage(new UnitConverterPage());
    }
}
