namespace AzureKeyVault
{
    public interface IVaultService
  {
    string GetKey(string keyName, string vaultName);
  }
}