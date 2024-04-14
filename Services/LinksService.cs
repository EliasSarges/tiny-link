using NanoidDotNet;

public class LinksService(LinkRepository linksRepository)
{
  private readonly LinkRepository linksRepository = linksRepository;

  async public Task<List<Link>> FindAll()
  {
    return await linksRepository.FindAll();
  }

  public async Task<Link?> FindById(string id)
  {
    return await linksRepository.FindById(id);
  }
  async public Task<Link> CreateLink(CreateLinkDTO data)
  {
    var id = Nanoid.Generate();
    return await linksRepository.CreateLink(new Link(id, data.Url, 0));
  }

  async public Task DeleteLink(string id)
  {
    await linksRepository.DeleteLink(id);
  }
}

public class CreateLinkDTO
{
  public string Url { get; set; } = "";
}
