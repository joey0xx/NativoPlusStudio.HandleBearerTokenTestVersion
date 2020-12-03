using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NativoPlusStudio.HandleBearerTokenTestVersion.Interfaces;

namespace NativoPlusStudio.HandleBearerTokenTest
{
    [TestClass]
    public class HandlerBearerTokenTest : BaseTestConfiguration
    {
        private readonly IAsymmetricEncryptionAndDecryptionBearerTokenService _asymmetricEncryptionAndDecryptionBearerTokenService;

        public HandlerBearerTokenTest()
        {
            _asymmetricEncryptionAndDecryptionBearerTokenService = serviceProvider.GetRequiredService<IAsymmetricEncryptionAndDecryptionBearerTokenService>();
        }
        [TestMethod]
        public string TestEncryptMethod(string text)
        {

            var response = _asymmetricEncryptionAndDecryptionBearerTokenService.AsymmetricEncrypt(text);

            Assert.IsTrue(response != null);                      
            return response;
        }

        [TestMethod]
        public void TestDecryptMethod()
        {
            var textToEncrypt = "Hello";
            var encryptedText = TestEncryptMethod(textToEncrypt);
            var decryptedMessage = _asymmetricEncryptionAndDecryptionBearerTokenService.AsymmetricDecrypt(encryptedText);

            Assert.IsTrue(decryptedMessage != null);
            Assert.AreEqual(decryptedMessage, textToEncrypt);

        }


    }
}
