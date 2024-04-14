public static class Utils
{
  public static bool ValidateUrl(string url)
  {
    return Uri.TryCreate(url, UriKind.Absolute, out _);
  }
}
