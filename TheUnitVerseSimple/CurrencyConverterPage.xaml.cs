using System.Net.Http.Json;

namespace TheUnitVerseSimple;

// Gets the CurrencyConverterPage which handles currency conversion logic and UI
public partial class CurrencyConverterPage : ContentPage
{
    // Gets the dictionary to store currency rates
    Dictionary<string, double> rates = new();

    // Gets the constructor for the page
    public CurrencyConverterPage()
    {
        InitializeComponent();
        LoadRates();
    }

    // Loads the latest currency exchange rates from the API
    async void LoadRates()
    {
        try
        {
            // Gets the exchange rates from the currency API
            var response = await new HttpClient().GetFromJsonAsync<ExchangeResponse>(
                "https://api.freecurrencyapi.com/v1/latest?apikey=fca_live_BYtRDAAI3WGjJasrnrQkVz1K5tYaAUJOmllv47fI");

            // Checks if the API returned valid data
            if (response?.data != null)
            {
                // Sets the rates dictionary to the fetched data
                rates = response.data;

                // Gets a sorted list of currency codes
                var currencies = rates.Keys.OrderBy(c => c).ToList();

                // Sets the list of currencies in the pickers
                FromCurrencyPicker.ItemsSource = currencies;
                ToCurrencyPicker.ItemsSource = currencies;

                // Sets default selected currencies
                FromCurrencyPicker.SelectedItem = "USD";
                ToCurrencyPicker.SelectedItem = "CAD";
            }
            else
            {
                // Shows an error alert if no data was received
                await DisplayAlert("Error", "No currency data received.", "OK");
            }
        }
        catch (Exception ex)
        {
            // Shows an error alert if the API call failed
            await DisplayAlert("Error", $"Failed to load rates: {ex.Message}", "OK");
        }
    }

    // Converts the amount when the convert button is clicked
    void OnConvertCurrencyClicked(object sender, EventArgs e)
    {
        // Checks if amount is valid and currencies are selected
        if (double.TryParse(AmountEntry.Text, out double amount)
            && FromCurrencyPicker.SelectedItem != null
            && ToCurrencyPicker.SelectedItem != null)
        {
            // Gets the selected source and target currencies
            string from = FromCurrencyPicker.SelectedItem.ToString();
            string to = ToCurrencyPicker.SelectedItem.ToString();

            // Converts the amount to USD first
            double usdAmount = amount / rates[from];

            // Converts the USD amount to the target currency
            double result = usdAmount * rates[to];

            // Displays the result on the screen
            CurrencyResultLabel.Text = $"Result: {result:F2} {to}";

            // Saves the conversion to the local database
            App.Database.SaveConversion($"Converted {amount} {from} to {to}: {result:F2}");
        }
    }

    // Gets the response structure for the currency API
    class ExchangeResponse
    {
        // Gets the dictionary of currency rates from the API
        public Dictionary<string, double> data { get; set; }
    }
}
