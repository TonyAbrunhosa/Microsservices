using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ConnectionNpgSql
{
    public class ConfigureNpgSql
    {
        private readonly RequestDelegate _next;

        public ConfigureNpgSql(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var mongoConn = (NpgSqlConn)httpContext.RequestServices.GetService(typeof(NpgSqlConn));
            var configuration = (IConfiguration)httpContext.RequestServices.GetService(typeof(IConfiguration));
            mongoConn.StringConnection = configuration.GetSection("DataBaseSettings:ConnectionString").Value;            

            return _next(httpContext);
        }
    }

    public static class ConfigureExtensions
    {
        public static IApplicationBuilder UseConfigureConnection(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ConfigureNpgSql>();
        }
    }
}
