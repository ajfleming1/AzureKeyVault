namespace AzureKeyVault
{
  internal interface IGitHubService
  {
    string GetRawContentUsingBearerToken(string user, string repository, string filePath, string token);
  }
}