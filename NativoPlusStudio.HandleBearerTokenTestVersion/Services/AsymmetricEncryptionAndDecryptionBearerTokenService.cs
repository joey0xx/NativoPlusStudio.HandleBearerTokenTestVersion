using NativoPlusStudio.HandleBearerTokenTestVersion.Helper;
using NativoPlusStudio.HandleBearerTokenTestVersion.Interfaces;
using Serilog;
using System;
using System.Security.Cryptography;
using System.Text;

namespace NativoPlusStudio.HandleBearerTokenTestVersion.Services
{
    public class AsymmetricEncryptionAndDecryptionBearerTokenService : IAsymmetricEncryptionAndDecryptionBearerTokenService
    {
        private readonly ILogger _logger;
        private readonly EncryptionConfiguration _encryptionConfiguration;
        public AsymmetricEncryptionAndDecryptionBearerTokenService(
            ILogger logger,
            EncryptionConfiguration encryptionConfiguration)
        {
            _logger = logger;
            _encryptionConfiguration = encryptionConfiguration;
        }

        public string AsymmetricEncrypt(string text)
        {            
                if(text != null)
                {
                    _logger.Information("#AsymmetricEncrypt");
                    byte[] data = Encoding.UTF8.GetBytes(text);
                    var rsa = _encryptionConfiguration.PublicKey;
                    byte[] cipherText = rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);

                    var encryptedDataToString = Convert.ToBase64String(cipherText);

                    _logger.Information($"#AsymmetricEncrypted string: {encryptedDataToString}");

                    return encryptedDataToString;
                }                
            

            return null;
        }

        public string AsymmetricDecrypt(string encriptedtext)
        {
           
                if (encriptedtext != null)
                {
                    _logger.Information("#AsymmetricEncrypt");
                    byte[] data = Convert.FromBase64String(encriptedtext);
                    var rsa = _encryptionConfiguration.GeneratedPrivateKey;
                    byte[] cipherText = rsa.Decrypt(data, RSAEncryptionPadding.Pkcs1);
                    var decryptedMessageToString = Encoding.UTF8.GetString(cipherText);

                    _logger.Information($"#AsymmetricEncrypted string: {decryptedMessageToString}");

                    return decryptedMessageToString;
                }
            
            return null; 
        }

        
    }
}
