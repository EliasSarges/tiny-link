public static class LinkController
{
  private static readonly LinksService linksService = new LinksService(new LinkRepository());
  public static void RegisterLinkController(this IEndpointRouteBuilder router)
  {
    router.MapGet("/links", async () => await linksService.FindAll());

    router.MapPost("/links", async (HttpContext context, CreateLinkDTO data) =>
    {
      if (!Utils.ValidateUrl(data.Url))
      {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsync("Invalid URL");

        return;
      }

      var newLink = await linksService.CreateLink(data);

      context.Response.StatusCode = StatusCodes.Status201Created;

      await context.Response.WriteAsJsonAsync(newLink);
    });


    router.MapDelete("/links/{id}", async (HttpContext context, string id) =>
    {
      var link = await linksService.FindById(id);

      if (link == null)
      {
        context.Response.StatusCode = StatusCodes.Status404NotFound;
        await context.Response.WriteAsync("Link not found");

        return;
      }

      await linksService.DeleteLink(id);

      context.Response.StatusCode = StatusCodes.Status204NoContent;
    });

    router.MapGet("/redirect/{id}", async (HttpContext context, string id) =>
    {
      var link = await linksService.FindById(id);

      if (link == null)
      {
        context.Response.StatusCode = StatusCodes.Status404NotFound;
        await context.Response.WriteAsync("Link not found");

        return;
      }

      context.Response.StatusCode = StatusCodes.Status200OK;
      context.Response.Redirect(link.Url);
    });
  }
}
