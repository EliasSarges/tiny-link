public class Link
{
  public string Id { get; set; }
  public string Url { get; set; }
  public int Clicks { get; set; }

  public Link(string id, string url, int clicks)
  {
    Id = id;
    Url = url;
    Clicks = clicks;
  }
}