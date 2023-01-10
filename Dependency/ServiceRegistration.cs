using Application.Interface;
using Application.Services;
using Infrastructure.Class;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Data;
using Presentation.View;

namespace Dependency
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ICountryRepo, CountryClass>();
            services.AddScoped<ICountryData, CountryView>();
            services.AddScoped(typeof(ICountry), typeof(CountryService));

            services.AddScoped<IUsersRepo, UsersClass>();
            services.AddScoped<IUsersData, UsersView>();
            services.AddScoped(typeof(IUsers), typeof(UsersServices));
        }
    }
}
