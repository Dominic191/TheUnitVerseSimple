using SQLite;

namespace TheUnitVerseSimple;

// Gets the model for a single conversion record
public class Conversion
{
    // Gets the primary key and auto-incrementing ID
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    // Gets the description of the conversion (e.g., "Converted 10 USD to CAD")
    public string Description { get; set; }
}

// Gets the class for handling the SQLite database
public class Database
{
    // Gets the private connection to the SQLite database
    private readonly SQLiteConnection _db;

    // Gets the constructor and sets up the database connection
    public Database(string dbPath)
    {
        // Creates the database connection
        _db = new SQLiteConnection(dbPath);

        // Creates the Conversion table if it doesn't already exist
        _db.CreateTable<Conversion>();
    }

    // Saves a new conversion record to the database
    public void SaveConversion(string description)
    {
        // Inserts a new conversion row into the Conversion table
        _db.Insert(new Conversion { Description = description });
    }

    // Gets the list of saved conversion descriptions in reverse order (most recent first)
    public List<string> GetConversions()
    {
        return _db.Table<Conversion>().Select(c => c.Description).Reverse().ToList();
    }
}
