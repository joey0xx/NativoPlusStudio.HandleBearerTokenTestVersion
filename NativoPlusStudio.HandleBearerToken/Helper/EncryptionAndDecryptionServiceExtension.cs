using Microsoft.Extensions.DependencyInjection;
using NativoPlusStudio.HandleBearerToken.Interfaces;
using NativoPlusStudio.HandleBearerToken.Services;

namespace NativoPlusStudio.HandleBearerToken.Helper
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

        }
    }
}
