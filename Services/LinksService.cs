using NanoidDotNet;

public class LinksService(LinkRepository linksRepository)
{
  private readonly LinkRepository linksRepository = linksRepository;

  public List<Link> FindAll()
  {
    return linksRepository.FindAll();
  }

  async public Task<Link> CreateLink(CreateLinkDTO data)
  {
    var id = Nanoid.Generate();
    return await linksRepository.CreateLink(new Link(id, data.Url, 0));
  }
}

public class CreateLinkDTO
{
  public string Url { get; set; } = "";
}
