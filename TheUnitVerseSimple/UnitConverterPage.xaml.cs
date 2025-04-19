using System;
using Microsoft.Maui.Controls;

namespace TheUnitVerseSimple;

public partial class UnitConverterPage : ContentPage
{
    Dictionary<string, (string[], Func<double, string, string, double>)> conversionMap;

    public UnitConverterPage()
    {
        InitializeComponent();

        conversionMap = UnitConverterLogic.GetConversionMap();
        UnitTypePicker.ItemsSource = conversionMap.Keys.ToList();

        UnitTypePicker.SelectedIndexChanged += (s, e) =>
        {
            var unitType = UnitTypePicker.SelectedItem?.ToString();
            if (unitType != null)
            {
                var units = conversionMap[unitType].Item1;
                FromUnitPicker.ItemsSource = units.ToList();
                ToUnitPicker.ItemsSource = units.ToList();
            }
        };
    }

    void OnConvertClicked(object sender, EventArgs e)
    {
        if (double.TryParse(InputEntry.Text, out double value)
            && FromUnitPicker.SelectedItem != null
            && ToUnitPicker.SelectedItem != null
            && UnitTypePicker.SelectedItem != null)
        {
            var unitType = UnitTypePicker.SelectedItem.ToString();
            var convertFunc = conversionMap[unitType].Item2;
            double result = convertFunc(value, FromUnitPicker.SelectedItem.ToString(), ToUnitPicker.SelectedItem.ToString());

            ResultLabel.Text = $"Result: {result}";
            App.Database.SaveConversion($"Converted {value} {FromUnitPicker.SelectedItem} to {ToUnitPicker.SelectedItem}: {result}");
        }
    }
}
