using Autofac;
using System;

namespace AzureKeyVault
{
  class Program
  {
    private static IContainer _container;
    private const string TemplateFilename = "receipt-template.cshtml";
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
        var key = vaultService.GetKey(KeyName);
        var template = gitHubService.GetTemplate(TemplateFilename, key);
        Console.WriteLine(template);
      }
    }
  }
}