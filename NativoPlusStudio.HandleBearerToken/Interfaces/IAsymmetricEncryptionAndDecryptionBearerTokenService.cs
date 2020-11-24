using System.Security.Cryptography;

namespace NativoPlusStudio.HandleBearerToken.Interfaces
{
    public interface IAsymmetricEncryptionAndDecryptionBearerTokenService
    {        
        string AsymmetricDecrypt(string encryptedText, RSAParameters rsaParameters);        
        string AsymmetricEncrypt(string privateKey, RSAParameters rsaParameters);
    }
}