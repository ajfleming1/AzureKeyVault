using System;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace AzureKeyVault
{
  internal class VaultService : IVaultService
  {
    public string GetKey(string keyName)
    {
      var keyVaultName = Environment.GetEnvironmentVariable("KEY_VAULT_NAME");
      var kvUri = "https://" + keyVaultName + ".vault.azure.net";
      var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
      Console.WriteLine("Retrieving your secret from " + keyVaultName + ".");
      KeyVaultSecret secret = client.GetSecret(keyName);
      return secret.Value;
    }
  }
}