public static class LinkController
{
  private static readonly LinksService linksService = new LinksService(new LinkRepository());
  public static void RegisterLinkController(this IEndpointRouteBuilder router)
  {
    RouteGroupBuilder linkRouteGroup = router.MapGroup("/links");

    linkRouteGroup.MapGet("/", linksService.FindAll);
  }
}