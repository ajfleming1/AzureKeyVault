namespace AzureKeyVault
{
  internal interface IVaultService
  {
    string GetKey(string keyName);
  }
}