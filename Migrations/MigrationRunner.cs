using Microsoft.Data.Sqlite;

public static class MigrationRunner
{
  public static void RunMigrations()
  {
    using var connection = new DatabaseManager();
    {
      IOrderedEnumerable<string> migrationFiles = Directory.GetFiles("Migrations", "*.sql").OrderBy(name => name);

      foreach (var migration in migrationFiles)
      {
        string sql = File.ReadAllText(migration);

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = sql;

        command.ExecuteNonQuery();
      }
    }
  }
}