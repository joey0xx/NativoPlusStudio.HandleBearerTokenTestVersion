using CertificateManager;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NativoPlusStudio.HandleBearerTokenTestVersion.EncryptDecryptLibrary;
using NativoPlusStudio.HandleBearerTokenTestVersion.Interfaces;
using NativoPlusStudio.HandleBearerTokenTestVersion.Services;
using Serilog;
using System;
using System.Globalization;
using System.Numerics;
using System.Security.Cryptography;

namespace NativoPlusStudio.HandleBearerTokenTestVersion.Helper
{
    public static class EncryptionAndDecryptionServiceExtension
    {
        public static void AddAsymmetricEncryptionAndDecryptionBearerToken(this IServiceCollection services, string myPrivateKey)
        {
            if (services == null)
            {
                services = new ServiceCollection();
            }
            services.AddTransient<IAsymmetricEncryptionAndDecryptionBearerTokenService, AsymmetricEncryptionAndDecryptionBearerTokenService>();
            services.AddSingleton(ConfigureEncryptionKey(myPrivateKey));

        }

        private static EncryptionConfiguration ConfigureEncryptionKey(string myPrivateKey)
        {
            //if(string.IsNullOrEmpty(privateKey))
            //{
            //    throw new Exception("The private key is empty");
            //}

            var serviceProvider = new ServiceCollection()
                .AddCertificateManager()
                .BuildServiceProvider();

            var cc = serviceProvider.GetService<CreateCertificates>();

            var certificate = CreateRsaCertificates.CreateRsaCertificate(cc, 512);
            
            return new EncryptionConfiguration
            {
                MyPrivateKey = myPrivateKey,
                PublicKey = Keys.CreateRsaPublicKey(certificate),
                GeneratedPrivateKey = Keys.CreateRsaPrivateKey(certificate)
            };
        }

        public static ILogger BuildCustomLogger(this ILogger log, IConfiguration configuration)
        {
            var loggerConfig = new LoggerConfiguration()
                  .ReadFrom.Configuration(configuration)
                      .Enrich.FromLogContext()
                      .Enrich.WithMachineName()
                      .Enrich.WithEnvironmentUserName()
                      .CreateLogger();
            return loggerConfig;
        }

        //Testing if I can get the public key from the private key using chilkat-x64 nuget package
        
        private static string GetPublicKeyFromPrivateKey(string myPrivateKey)
        {           

            var key = new Chilkat.PrivateKey();                       
            key.LoadPem(myPrivateKey);

            //  Step 2: Get the public key object from the private key object.
            
            var pubKey = key.GetPublicKey();
            //var value = "";
            var publicKey = pubKey.GetXml();
            return publicKey;


            //  Step 3: Save the public key in a desired format.
            //  (Chilkat can load or save public and private keys in many different formats.  See
            //  the online reference documentation for more options.)

        }


    }
}
