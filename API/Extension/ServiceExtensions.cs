using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Extension
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        //public static void Register(HttpConfiguration config)
        //{
        //    EnableCorsAttribute cros = new EnableCorsAttribute("*", "*", "*");
        //    config.EnableCors(cros);
        //}
    }
}
