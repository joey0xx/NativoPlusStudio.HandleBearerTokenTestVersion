using NativoPlusStudio.HandleBearerToken.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace NativoPlusStudio.HandleBearerToken.Services
{
    public class AsymmetricEncryptionAndDecryptionBearerTokenService : IAsymmetricEncryptionAndDecryptionBearerTokenService
    {
        public AsymmetricEncryptionAndDecryptionBearerTokenService()
        { }

        public string AsymmetricEncrypt(string privateKey)
        {
            if (privateKey != null)
            {
                RSA rsa = RSA.Create();
                byte[] data = Encoding.UTF8.GetBytes(privateKey);
                byte[] dataToEncrypt = rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);
                return Convert.ToBase64String(dataToEncrypt);
            }
            return string.Empty;
        }

        public string AsymmetricEncrypt2(string privateKey, RSAParameters rsaParameters)
        {
            byte[] data = Encoding.UTF8.GetBytes(privateKey);
            byte[] encryptedData;

            using (var rsaCryptoServiceProviderWriter = new RSACryptoServiceProvider())
            {
                rsaCryptoServiceProviderWriter.ImportParameters(rsaParameters);

                encryptedData = rsaCryptoServiceProviderWriter.Encrypt(data, RSAEncryptionPadding.Pkcs1);
            }

            return Convert.ToBase64String(encryptedData);
        }

        public string AsymmetricDecrypt(string encryptedText)
        {
            RSA rsa = RSA.Create();
            byte[] data = Convert.FromBase64String(encryptedText);
            byte[] dataToDecrypt = rsa.Decrypt(data, RSAEncryptionPadding.Pkcs1);
            return Encoding.UTF8.GetString(dataToDecrypt);
        }

        public string AsymmetricDecrypt2(string encryptedText, RSAParameters rsaParameters)
        {
            byte[] data = Convert.FromBase64String(encryptedText);
            byte[] decryptedMessage;

            using (var rsaCryptoServiceProviderReader = new RSACryptoServiceProvider())
            {
                rsaCryptoServiceProviderReader.ImportParameters(rsaParameters);

                decryptedMessage = rsaCryptoServiceProviderReader.Decrypt(data, RSAEncryptionPadding.Pkcs1);
            }

            return Encoding.UTF8.GetString(decryptedMessage);
        }
    }
}
