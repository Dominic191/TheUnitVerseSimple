namespace TheUnitVerseSimple;

// Gets the page that displays the history of conversions
public partial class HistoryPage : ContentPage
{
    // Gets the constructor for the history page
    public HistoryPage()
    {
        // Initializes the UI components of the page
        InitializeComponent();

        // Loads the history data into the view
        LoadHistory();
    }

    // Loads the conversion history from the database into the list view
    void LoadHistory()
    {
        // Gets the list of saved conversions and sets it as the item source for the view
        HistoryView.ItemsSource = App.Database.GetConversions();
    }
}
