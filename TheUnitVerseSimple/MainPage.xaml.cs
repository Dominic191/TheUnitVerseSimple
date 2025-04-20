namespace TheUnitVerseSimple;

// Gets the main unit conversion page
public partial class MainPage : ContentPage
{
    // Gets the map of unit types to their units and conversion functions
    Dictionary<string, (string[], Func<double, string, string, double>)> conversionMap;

    // Gets the constructor for the main page
    public MainPage()
    {
        // Initializes UI components
        InitializeComponent();

        // Gets the conversion map from the logic class
        conversionMap = UnitConverterLogic.GetConversionMap();

        // Sets the available unit types in the picker
        UnitTypePicker.ItemsSource = conversionMap.Keys.ToList();

        // Updates the "From" and "To" unit pickers when the unit type changes
        UnitTypePicker.SelectedIndexChanged += (s, e) =>
        {
            var unitType = UnitTypePicker.SelectedItem?.ToString();
            if (unitType != null)
            {
                // Gets the units for the selected type and sets them in the pickers
                var units = conversionMap[unitType].Item1;
                FromUnitPicker.ItemsSource = units;
                ToUnitPicker.ItemsSource = units;
            }
        };

        // Loads the conversion history on page load
        LoadHistory();
    }

    // Converts the input value when the convert button is clicked
    void OnConvertClicked(object sender, EventArgs e)
    {
        // Checks if the input is valid and all selections are made
        if (double.TryParse(InputEntry.Text, out double value)
            && FromUnitPicker.SelectedItem != null
            && ToUnitPicker.SelectedItem != null
            && UnitTypePicker.SelectedItem != null)
        {
            // Gets the selected unit type
            var unitType = UnitTypePicker.SelectedItem.ToString();

            // Gets the conversion function for the unit type
            var convertFunc = conversionMap[unitType].Item2;

            // Converts the value using the selected units
            double result = convertFunc(value,
                                        FromUnitPicker.SelectedItem.ToString(),
                                        ToUnitPicker.SelectedItem.ToString());

            // Displays the result
            ResultLabel.Text = $"Result: {result}";

            // Creates a history entry and saves it to the database
            string historyEntry = $"Converted {value} {FromUnitPicker.SelectedItem} to {ToUnitPicker.SelectedItem}: {result}";
            App.Database.SaveConversion(historyEntry);

            // Reloads the updated history
            LoadHistory();
        }
    }

    // Loads the conversion history from the database
    void LoadHistory()
    {
        HistoryView.ItemsSource = App.Database.GetConversions();
    }
}
