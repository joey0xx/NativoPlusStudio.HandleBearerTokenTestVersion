
namespace NativoPlusStudio.HandleBearerTokenTestVersion.Interfaces
{
    public interface IAsymmetricEncryptionAndDecryptionBearerTokenService
    {
        string AsymmetricEncrypt(string text);
        string AsymmetricDecrypt(string encriptedtext);
        
    }
}