//Based on koolin's repo: https://github.com/CdsWeb-app/CdsWeb/blob/master/src/CdsWeb/Extensions/CdsServiceClientExtensions.cs

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Powerplatform.Cds.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace web.Extensions
{
    public static class CdsServiceCollectionExtensions
    {
        /// <summary>
        /// Include a CdsServiceClient as a singleton service within the Service Collection
        /// Optional include transient services for IOrganizationService <see cref="IOrganizationService"/>
        /// and OrganizationServiceContext <see cref="OrganizationServiceContext"/>
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configureOptions"><see cref="CdsServiceClientOptions"/></param>
        public static void AddCdsServiceClient(this IServiceCollection services, Action<CdsServiceClientOptions> configureOptions)
        {
            CdsServiceClientOptions cdsServiceClientOptions = new CdsServiceClientOptions();
            configureOptions(cdsServiceClientOptions);

            services.AddSingleton(sp =>
                new CdsServiceClientWrapper(
                    cdsServiceClientOptions.ConnectionString,
                    sp.GetRequiredService<ILogger<CdsServiceClientWrapper>>(),
                    cdsServiceClientOptions.TraceLevel)
                );

            services.AddTransient<IOrganizationService, CdsServiceClient>(sp =>
                sp.GetService<CdsServiceClientWrapper>().CdsServiceClient.Clone());

            if (cdsServiceClientOptions.IncludeOrganizationServiceContext)
            {
                services.AddTransient(sp =>
                    new OrganizationServiceContext(sp.GetService<IOrganizationService>()));
            }
        }
    }
}