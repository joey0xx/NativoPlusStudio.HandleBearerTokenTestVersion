using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NativoPlusStudio.HandleBearerToken.Interfaces;

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
        public string TestEncryptMethods(string text)
        {

            var response = _asymmetricEncryptionAndDecryptionBearerTokenService.Encrypt(text);

            Assert.IsTrue(response != null);                      
            return response;
        }

        [TestMethod]
        public void TestDecryptMethods()
        {
            var textToEncrypt = "Hello";
            var encryptedText = TestEncryptMethods(textToEncrypt);
            var response = _asymmetricEncryptionAndDecryptionBearerTokenService.Decrypt(encryptedText);

            Assert.IsTrue(response != null);
            //Assert.AreEqual(response , textToEncrypt);

        }


    }
}
