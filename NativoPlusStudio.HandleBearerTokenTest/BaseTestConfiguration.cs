using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NativoPlusStudio.HandleBearerTokenTestVersion.Helper;
using Serilog;


namespace NativoPlusStudio.HandleBearerTokenTest
{
    public abstract class BaseTestConfiguration
    {
        public readonly IServiceProvider serviceProvider;
        
        
        public BaseTestConfiguration()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .Build();

            var key = "Test";
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton(x => Log.Logger.BuildCustomLogger(configuration));
            services.AddAsymmetricEncryptionAndDecryptionBearerToken(key);
            serviceProvider = services.BuildServiceProvider();
        }

        
    }
}
