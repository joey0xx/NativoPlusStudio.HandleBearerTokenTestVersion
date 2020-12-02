using System.Security.Cryptography;

namespace NativoPlusStudio.HandleBearerToken.Interfaces
{
    public interface IAsymmetricEncryptionAndDecryptionBearerTokenService
    {
        string Encrypt(string text);
        string Decrypt(string text);
        //string AsymmetricDecrypt(string encryptedText);        
        //string AsymmetricEncrypt(string text);
    }
}