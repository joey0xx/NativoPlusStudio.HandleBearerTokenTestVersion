using System.Security.Cryptography;

namespace NativoPlusStudio.HandleBearerToken.Interfaces
{
    public interface IAsymmetricEncryptionAndDecryptionBearerTokenService
    {
        string AsymmetricDecrypt(string encryptedText);
        string AsymmetricDecrypt2(string encryptedText, RSAParameters rsaParameters);
        string AsymmetricEncrypt(string privateKey);
        string AsymmetricEncrypt2(string privateKey, RSAParameters rsaParameters);
    }
}