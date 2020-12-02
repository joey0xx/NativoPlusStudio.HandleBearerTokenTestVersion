using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace NativoPlusStudio.HandleBearerToken.Interfaces
{
    public class EncryptionConfiguration
    {
        public string PrivateKey { get; set; }
        public RSA PublicKey { get; set; }
        public RSA GeneratedPrivateKey { get; set; }

        
    }
}
