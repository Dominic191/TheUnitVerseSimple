using System.Net.Http.Json;

namespace TheUnitVerseSimple;

public partial class CurrencyConverterPage : ContentPage
{
    Dictionary<string, double> rates = new();

    public CurrencyConverterPage()
    {
        InitializeComponent();
        LoadRates();
    }

    async void LoadRates()
    {
        try
        {
            var response = await new HttpClient().GetFromJsonAsync<ExchangeResponse>(
                "https://api.exchangerate.host/latest?base=USD");

            if (response?.rates != null)
            {
                rates = response.rates;
                var currencies = rates.Keys.OrderBy(c => c).ToList();
                FromCurrencyPicker.ItemsSource = currencies;
                ToCurrencyPicker.ItemsSource = currencies;

                FromCurrencyPicker.SelectedItem = "USD";
                ToCurrencyPicker.SelectedItem = "CAD";
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to load rates: {ex.Message}", "OK");
        }
    }

    void OnConvertCurrencyClicked(object sender, EventArgs e)
    {
        if (double.TryParse(AmountEntry.Text, out double amount)
            && FromCurrencyPicker.SelectedItem != null
            && ToCurrencyPicker.SelectedItem != null)
        {
            string from = FromCurrencyPicker.SelectedItem.ToString();
            string to = ToCurrencyPicker.SelectedItem.ToString();

            double usdAmount = amount / rates[from]; // convert to base USD
            double result = usdAmount * rates[to];   // convert USD to target

            CurrencyResultLabel.Text = $"Result: {result:F2} {to}";
            App.Database.SaveConversion($"Converted {amount} {from} to {to}: {result:F2}");
        }
    }

    class ExchangeResponse
    {
        public Dictionary<string, double> rates { get; set; }
    }
}
