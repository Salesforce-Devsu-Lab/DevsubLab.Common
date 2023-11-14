using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Devsulab.Common.Settings;
using NetCoreForce.Client;
using System;

namespace Devsulab.Common.SalesForce
{
    public static class Extensions
    {
        
        public static IServiceCollection AddSalesForce(this IServiceCollection services)
        {
            services.AddSingleton(serviceProvider =>
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                var salesForceSettings = configuration?.GetSection(nameof(SalesForceSettings)).Get<SalesForceSettings>();
                
                if (salesForceSettings == null)
                {
                    throw new ArgumentException("SalesForceSettings not configured properly.");
                }
                
                AuthenticationClient auth = new AuthenticationClient();
                auth.UsernamePassword(salesForceSettings?.ClientId, salesForceSettings?.ClientSecret, salesForceSettings?.Username, salesForceSettings?.Password, salesForceSettings?.TokenEndpointUrl);
                ForceClient client = new ForceClient(auth.AccessInfo.InstanceUrl, auth.ApiVersion, auth.AccessInfo.AccessToken);
                return client;
            });
            return services;
        }

        public static IServiceCollection AddSalesForceRepository<T>(this IServiceCollection services) where T : IEntity
        {
            services.AddSingleton<IRepository<T>>(serviceProvider =>
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                var salesForceSettings = configuration?.GetSection(nameof(SalesForceSettings)).Get<SalesForceSettings>();
                AuthenticationClient auth = new AuthenticationClient();
                auth.UsernamePassword(salesForceSettings?.ClientId, salesForceSettings?.ClientSecret, salesForceSettings?.Username, salesForceSettings?.Password, salesForceSettings?.TokenEndpointUrl);
                var client = new ForceClient(auth.AccessInfo.InstanceUrl, auth.ApiVersion, auth.AccessInfo.AccessToken);
                return new SalesForceRepository<T>(client);
            });
            return services;
        }
        
    }
}