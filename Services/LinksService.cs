public class LinksService(LinkRepository linksRepository)
{
  private readonly LinkRepository linksRepository = linksRepository;

  public List<Link> FindAll()
  {
    return linksRepository.FindAll();
  }
}