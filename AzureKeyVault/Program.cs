using System;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace AzureKeyVault
{
  class Program
  {
    static void Main(string[] args)
    {
      string secretName = "mySecret";

      string keyVaultName = Environment.GetEnvironmentVariable("KEY_VAULT_NAME");
      var kvUri = "https://" + keyVaultName + ".vault.azure.net";

      var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

      Console.Write("Input the value of your secret > ");
      string secretValue = Console.ReadLine();

      Console.Write("Creating a secret in " + keyVaultName + " called '" + secretName + "' with the value '" + secretValue + "` ...");

      client.SetSecret(secretName, secretValue);

      Console.WriteLine(" done.");

      Console.WriteLine("Forgetting your secret.");
      secretValue = "";
      Console.WriteLine("Your secret is '" + secretValue + "'.");

      Console.WriteLine("Retrieving your secret from " + keyVaultName + ".");

      KeyVaultSecret secret = client.GetSecret(secretName);

      Console.WriteLine("Your secret is '" + secret.Value + "'.");

      Console.Write("Deleting your secret from " + keyVaultName + " ...");

      client.StartDeleteSecret(secretName);

      System.Threading.Thread.Sleep(5000);
      Console.WriteLine(" done.");

    }
  }
}