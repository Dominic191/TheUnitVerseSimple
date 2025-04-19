namespace TheUnitVerseSimple;

public partial class CustomNavBar : ContentView
{
    public CustomNavBar()
    {
        InitializeComponent();
    }

    async void Home_Clicked(object sender, EventArgs e)
    {
        await Application.Current.MainPage.Navigation.PushAsync(new UnitConverterPage());
    }

    async void Currency_Clicked(object sender, EventArgs e)
    {
        await Application.Current.MainPage.Navigation.PushAsync(new CurrencyConverterPage());
    }

    async void History_Clicked(object sender, EventArgs e)
    {
        await Application.Current.MainPage.Navigation.PushAsync(new HistoryPage());
    }
}
