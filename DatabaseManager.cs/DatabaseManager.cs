using Microsoft.Data.Sqlite;

public class DatabaseManager : IDisposable
{
  private readonly SqliteConnection connection;

  public DatabaseManager()
  {
    connection = new SqliteConnection("Data Source=database.db");

    if (connection.State != System.Data.ConnectionState.Open)
    {
      connection.Open();
    }
  }

  public SqliteCommand CreateCommand()
  {
    return connection.CreateCommand();
  }

  public void Dispose()
  {
    if (connection.State != System.Data.ConnectionState.Closed)
    {
      connection.Close();
    }

    connection.Dispose();
  }
}
