public class LinkRepository
{
  async public Task<List<Link>> FindAll()
  {
    List<Link> links = [];

    using (var sqliteConnection = new DatabaseManager())
    {
      var command = sqliteConnection.CreateCommand();

      command.CommandText = "SELECT * FROM links";

      using (var reader = await command.ExecuteReaderAsync())
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

  async public Task<Link?> FindById(string id)
  {
    using (var sqliteConnection = new DatabaseManager())
    {
      var command = sqliteConnection.CreateCommand();
      command.CommandText = $"SELECT * FROM links where id = '{id}'";

      using (var reader = await command.ExecuteReaderAsync())
      {

        if (reader.Read())
        {
          return new Link(reader.GetString(0), reader.GetString(1), reader.GetInt32(2));
        }

        return null;
      }
    }
  }

  async public Task<Link> CreateLink(Link newLink)
  {
    using (var sqliteConnection = new DatabaseManager())
    {
      var command = sqliteConnection.CreateCommand();

      command.CommandText = $"INSERT INTO links (id, url, clicks) values ('{newLink.Id}', '{newLink.Url}', {newLink.Clicks})";
      await command.ExecuteNonQueryAsync();
    }

    return newLink;
  }

  async public Task DeleteLink(string id)
  {
    using (var sqliteConnection = new DatabaseManager())
    {
      var command = sqliteConnection.CreateCommand();

      command.CommandText = $"DELETE FROM links WHERE id = '{id}'";

      await command.ExecuteNonQueryAsync();
    }
  }
}
