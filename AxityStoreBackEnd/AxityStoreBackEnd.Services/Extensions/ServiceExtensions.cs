using AxityStoreBackEnd.Domain.Interfaces;
using AxityStoreBackEnd.Infrastructure.Data.Repositories;
using AxityStoreBackEnd.Infrastructure.Interfaces;
using AxityStoreBackEnd.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AxityStoreBackEnd.Services.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
