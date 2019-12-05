using System;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace AzureKeyVault
{
    public class VaultService : IVaultService
    {
        public string GetKey(string keyName, string vaultName)
        {
            var kvUri = "https://" + vaultName + ".vault.azure.net";
            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
            Console.WriteLine("Retrieving your secret from " + vaultName + ".");
            KeyVaultSecret secret = client.GetSecret(keyName);
            return secret.Value;
        }
    }
}