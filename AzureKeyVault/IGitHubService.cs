namespace AzureKeyVault
{
  public interface IGitHubService
  {
    string GetRawContentUsingBearerToken(string user, string repository, string filePath, string token);
  }
}