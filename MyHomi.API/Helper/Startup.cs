using MyHomi.PropertyManager.DataAccess;
using MyHomi.PropertyManager.DataAccess.Implementation;
using MyHomi.PropertyManager.DataAccess.Interface;
using MyHomi.PropertyManager.Service.Implementation;
using MyHomi.PropertyManager.Service.Interface;
using MyHomi.PropertyManager.Utility.Extensions;

namespace MyHomi.API.Helper
{
    public static class Startup
    {

        public static void WebStartup(this IServiceCollection services, IConfiguration configuration)
        {
            AddCorsPolicies(services);
            AddCacheServices(services, configuration);
            AddModuleInstance(services, configuration);
        }


        public static void AddCorsPolicies(this IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("MyPolicy", options => options.AllowAnyOrigin()
                                                          .AllowAnyMethod()
                                                          .AllowAnyHeader()
               );
            });
        }


        public static void AddCacheServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSingleton<ICache, RedisCache>();
        }


        public static void AddModuleInstance(this IServiceCollection services, IConfiguration configuration)
        {
            //Inject Property module
            services.AddPropertyInstance(configuration);

            //Service
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

    }
}
