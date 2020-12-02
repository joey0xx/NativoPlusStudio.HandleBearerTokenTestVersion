using NativoPlusStudio.HandleBearerToken.Interfaces;
using Serilog;
using System;
using System.Security.Cryptography;
using System.Text;

namespace NativoPlusStudio.HandleBearerToken.Services
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

        public string Encrypt(string text)
        {
            byte[] data = Encoding.UTF8.GetBytes(text);
            var rsa = _encryptionConfiguration.PublicKey;
            byte[] cipherText = rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);
            return Convert.ToBase64String(cipherText);
        }

        public string Decrypt(string text)
        {
            _logger.Information("#AsymmetricEncrypt");
            byte[] data = Convert.FromBase64String(text);
            var rsa = _encryptionConfiguration.GeneratedPrivateKey;
            byte[] cipherText = rsa.Decrypt(data, RSAEncryptionPadding.Pkcs1);
            var encryptedDataToString = Encoding.UTF8.GetString(cipherText);

            _logger.Information($"#AsymmetricEncrypted string: {encryptedDataToString}");

            return encryptedDataToString;
        }

        //public string AsymmetricEncrypt(string text)
        //{
        //    //_logger.Information("#AsymmetricEncrypt");
        //    byte[] data = Encoding.UTF8.GetBytes(text);
        //    byte[] encryptedData;

        //    using (var rsaCryptoServiceProviderWriter = new RSACryptoServiceProvider())
        //    {
        //        rsaCryptoServiceProviderWriter.ImportParameters(_encryptionConfiguration.PublicParameters);

        //        encryptedData = rsaCryptoServiceProviderWriter.Encrypt(data, RSAEncryptionPadding.Pkcs1);
        //    }

        //    var encryptedDataToString = Convert.ToBase64String(encryptedData);
        //   // _logger.Information($"#AsymmetricEncrypted string: {encryptedDataToString}");
        //    return encryptedDataToString;
        //}


        //public string AsymmetricDecrypt(string encryptedText)
        //{
        //    //_logger.Information("#AsymmetricDecrypt");
        //    byte[] data = Convert.FromBase64String(encryptedText);
        //    byte[] decryptedMessage;

        //    using (var rsaCryptoServiceProviderReader = new RSACryptoServiceProvider())
        //    {
        //        rsaCryptoServiceProviderReader.ImportParameters(_encryptionConfiguration.PrivateParameters);

        //        decryptedMessage = rsaCryptoServiceProviderReader.Decrypt(data, RSAEncryptionPadding.Pkcs1);
        //    }

        //    var decryptedMessageToString = Encoding.UTF8.GetString(decryptedMessage);
        //    //_logger.Information($"#AsymmetricEncrypted string: {decryptedMessageToString}");
        //    return decryptedMessageToString;
        //}
    }
}
