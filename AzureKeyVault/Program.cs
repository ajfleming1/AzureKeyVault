using Autofac;
using System;

namespace AzureKeyVault
{
  class Program
  {
    private static IContainer _container;
    private const string Repository = "support-clients";
    private const string User = "ajfleming1";
    private const string FilePath = "receipt-template.cshtml";
    private const string KeyName = "SupportClients";

    static void Main()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<VaultService>().As<IVaultService>();
      builder.RegisterType<GitHubService>().As<IGitHubService>();
      _container = builder.Build();

      PrintTemplate();

      Console.ReadLine();
    }

    private static void PrintTemplate()
    {
      using (var scope = _container.BeginLifetimeScope())
      {
        var vaultService = scope.Resolve<IVaultService>();
        var gitHubService = scope.Resolve<IGitHubService>();
        var gitHubToken = vaultService.GetKey(KeyName);
        var template = gitHubService.GetRawContentUsingBearerToken(User, Repository, FilePath, gitHubToken);
        Console.WriteLine(template);
      }
    }
  }
}