namespace TheUnitVerseSimple;

// Gets the custom navigation bar used across pages
public partial class CustomNavBar : ContentView
{
    // Gets the constructor for the custom navigation bar
    public CustomNavBar()
    {
        InitializeComponent();
    }

    // Navigates to the Unit Converter page when Home is clicked
    async void Home_Clicked(object sender, EventArgs e)
    {
        await Application.Current.MainPage.Navigation.PushAsync(new UnitConverterPage());
    }

    // Navigates to the Currency Converter page when Currency is clicked
    async void Currency_Clicked(object sender, EventArgs e)
    {
        await Application.Current.MainPage.Navigation.PushAsync(new CurrencyConverterPage());
    }
}
