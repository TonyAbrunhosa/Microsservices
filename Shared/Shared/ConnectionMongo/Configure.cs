using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ConnectionMongo
{
    public class Configure
    {
        private readonly RequestDelegate _next;

        public Configure(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var mongoConn = (MongoConn)httpContext.RequestServices.GetService(typeof(MongoConn));
            var configuration = (IConfiguration)httpContext.RequestServices.GetService(typeof(IConfiguration));
            mongoConn.StringConnection = configuration.GetSection("ConnectionString:Mongo").Value;
            mongoConn.NameCollection = configuration.GetSection("ConnectionString:NameCollection").Value;
            mongoConn.NameDataBase = configuration.GetSection("ConnectionString:NomeDataBase").Value;

            return _next(httpContext);
        }        
    }

    public static class ConfigureExtensions
    {
        public static IApplicationBuilder UseConfigure(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Configure>();
        }
    }
}
