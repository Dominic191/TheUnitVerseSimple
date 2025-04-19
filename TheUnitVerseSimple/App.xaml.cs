using System;
using System.IO;
using Microsoft.Maui.Controls;

namespace TheUnitVerseSimple;

public partial class App : Application
{
    public static Database Database;

    public App()
    {
        InitializeComponent();

        string dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "unitverse.db3");

        Database = new Database(dbPath);

        MainPage = new NavigationPage(new UnitConverterPage());
    }
}
