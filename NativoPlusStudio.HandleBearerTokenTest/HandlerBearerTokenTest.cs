using Microsoft.VisualStudio.TestTools.UnitTesting;
using NativoPlusStudio.HandleBearerToken.Services;
using System.Security.Cryptography;

namespace NativoPlusStudio.HandleBearerTokenTest
{
    [TestClass]
    public class HandlerBearerTokenTest
    {
        [TestMethod]
        public void TesEncryptAndDecryptMethods()
        {
            var text = "Hello";

            var rsaCryptoServiceProvider = new RSACryptoServiceProvider();
            var publicParameters = rsaCryptoServiceProvider.ExportParameters(false);
            var privateParameters = rsaCryptoServiceProvider.ExportParameters(true);            

            var asymmetricEncryptDecrypt = new AsymmetricEncryptionAndDecryptionBearerTokenService();

            var encryptedText = asymmetricEncryptDecrypt.AsymmetricEncrypt(text, publicParameters);
            asymmetricEncryptDecrypt.AsymmetricDecrypt(encryptedText, privateParameters);
        }
    }
}
