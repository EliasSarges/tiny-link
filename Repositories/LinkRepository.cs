public class LinkRepository
{
  public List<Link> FindAll()
  {
    List<Link> links = [];


    using (var sqliteConnection = new DatabaseManager())
    {
      var command = sqliteConnection.CreateCommand();

      command.CommandText = "SELECT * FROM links";

      using (var reader = command.ExecuteReader())
      {
        while (reader.Read())
        {
          var link = new Link(reader.GetString(0), reader.GetString(1), reader.GetInt32(2));

          links.Add(link);
        }
      };
    }

    return links;
  }
}
