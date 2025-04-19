using SQLite;

namespace TheUnitVerseSimple;

public class Conversion
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Description { get; set; }
}

public class Database
{
    private readonly SQLiteConnection _db;

    public Database(string dbPath)
    {
        _db = new SQLiteConnection(dbPath);
        _db.CreateTable<Conversion>();
    }

    public void SaveConversion(string description)
    {
        _db.Insert(new Conversion { Description = description });
    }

    public List<string> GetConversions()
    {
        return _db.Table<Conversion>().Select(c => c.Description).Reverse().ToList();
    }
}
