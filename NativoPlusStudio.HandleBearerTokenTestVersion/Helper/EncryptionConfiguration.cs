using System.Security.Cryptography;

namespace NativoPlusStudio.HandleBearerTokenTestVersion.Helper
{
    public class EncryptionConfiguration
    {
        public string MyPrivateKey { get; set; }
        public RSA PublicKey { get; set; }
        public RSA GeneratedPrivateKey { get; set; }

        
    }
}
