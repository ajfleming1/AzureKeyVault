namespace AzureKeyVault
{
  internal interface IGitHubService
  {
    string GetTemplate(string templateFilename, string key);
  }
}