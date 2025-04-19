namespace TheUnitVerseSimple;

public partial class HistoryPage : ContentPage
{
    public HistoryPage()
    {
        InitializeComponent();
        LoadHistory();
    }

    void LoadHistory()
    {
        HistoryView.ItemsSource = App.Database.GetConversions();
    }
}
