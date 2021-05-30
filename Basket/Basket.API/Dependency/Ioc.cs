using Basket.Application.Service;
using Basket.Domain.Contracts.IRepository;
using Basket.Domain.Contracts.IService;
using Basket.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.API.Dependency
{
    public static class Ioc
    {
        public static IServiceCollection ResolveDependency(this IServiceCollection services)
        {
            //services.AddScoped<MongoConn, MongoConn>();

            services.AddTransient<IBasketRepository, BasketRepository>();
            services.AddTransient<IBasketService, BasketService>();

            return services;
        }
    }
}
