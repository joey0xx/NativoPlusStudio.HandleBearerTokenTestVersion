using CertificateManager;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NativoPlusStudio.HandleBearerTokenTestVersion.EncryptDecryptLibrary;
using NativoPlusStudio.HandleBearerTokenTestVersion.Interfaces;
using NativoPlusStudio.HandleBearerTokenTestVersion.Services;
using Serilog;
using System;


namespace NativoPlusStudio.HandleBearerTokenTestVersion.Helper
{
    public static class EncryptionAndDecryptionServiceExtension
    {
        public static void AddAsymmetricEncryptionAndDecryptionBearerToken(this IServiceCollection services, string privateKey)
        {
            if (services == null)
            {
                services = new ServiceCollection();
            }
            services.AddTransient<IAsymmetricEncryptionAndDecryptionBearerTokenService, AsymmetricEncryptionAndDecryptionBearerTokenService>();
            services.AddSingleton(ConfigureEncryptionKey(privateKey));

        }

        private static EncryptionConfiguration ConfigureEncryptionKey(string privateKey)
        {
            if(string.IsNullOrEmpty(privateKey))
            {
                throw new Exception("The private key is empty");
            }

            var serviceProvider = new ServiceCollection()
                .AddCertificateManager()
                .BuildServiceProvider();

            var cc = serviceProvider.GetService<CreateCertificates>();

            var cert3072 = CreateRsaCertificates.CreateRsaCertificate(cc, 512);

            return new EncryptionConfiguration
            {
                PrivateKey = privateKey,
                PublicKey = Keys.CreateRsaPublicKey(cert3072),
                GeneratedPrivateKey = Keys.CreateRsaPrivateKey(cert3072)
            };
        }

        public static ILogger BuildCustomLogger(this ILogger log, IConfiguration configuration)
        {
            var loggerConfig = new LoggerConfiguration()
                      .CreateLogger();
            return loggerConfig;
        }
    }
}
