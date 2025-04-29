using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MyHomi.PropertyManager.Utility.Config;

namespace MyHomi.PropertyManager.Utility.Extensions
{
    public static class ServiceConfigurationExtensions
    {
        #region Public methods

        public static void AddPropertyInstance(this IServiceCollection services, IConfiguration configuration)
        {
            AddConfigurations(services, configuration);
            AddServiceinstance(services);
            AddRepoInstance(services);
        }

        #endregion


        #region Private methods

        private static void AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(
                configuration!.GetSection(nameof(AppSettings)));

            services.AddSingleton<IAppSettings>(sp =>
                sp.GetRequiredService<IOptions<AppSettings>>().Value);
        }


        private static void AddServiceinstance(this IServiceCollection services)
        {
            //services?.AddSingleton<PropertyService>();
        }


        private static void AddRepoInstance(this IServiceCollection services)
        {
            //Inject all repos
        }

        #endregion
    }
}
