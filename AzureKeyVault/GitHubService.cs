using System.Net;

namespace AzureKeyVault
{
  internal class GitHubService : IGitHubService
  {
    public string GetTemplate(string templateFilename, string key)
    {
      var client = new WebClient();
      client.Headers.Add("Authorization", $"bearer {key}");
      var url = $"https://raw.githubusercontent.com/ajfleming1/support-clients/master/{templateFilename}";
      var response = client.DownloadString($"{url}");

      return response;
    }
  }
}