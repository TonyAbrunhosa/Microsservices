using Catalog.Application.Service;
using Catalog.Domain.Contracts.IRepository;
using Catalog.Domain.Contracts.IService;
using Catalog.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using Shared.ConnectionMongo;

namespace Catalog.API.Dependency
{
    public static class Ioc
    {
        public static IServiceCollection ResolveDependency(this IServiceCollection services)
        {
            services.AddScoped<MongoConn, MongoConn>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();

            return services;
        }
    }
}
