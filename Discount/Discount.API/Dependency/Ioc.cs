using Discount.Application.Service;
using Discount.Domain.Contracts.IRepository;
using Discount.Domain.Contracts.IService;
using Discount.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using Shared.ConnectionNpgSql;

namespace Discount.API.Dependency
{
    public static class Ioc
    {
        public static IServiceCollection ResolveDependency(this IServiceCollection services)
        {
            services.AddScoped<NpgSqlConn, NpgSqlConn>();

            services.AddTransient<IDiscountRepository, DiscountRepository>();
            services.AddTransient<IDiscountService, DiscountService>();

            return services;
        }
    }
}
