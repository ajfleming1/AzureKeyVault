using System.Net;

namespace AzureKeyVault
{
  internal class GitHubService : IGitHubService
  {
    public string GetRawContentUsingBearerToken(string user, string repository, string filePath, string token)
    {
      var client = new WebClient();
      client.Headers.Add("Authorization", $"bearer {token}");
      var url = $"https://raw.githubusercontent.com/{user}/{repository}/master/{filePath}";
      var response = client.DownloadString($"{url}");

      return response;
    }
  }
}