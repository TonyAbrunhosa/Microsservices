using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace Shared.Configuration
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, string Title, string Version)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = Title, Version = Version });
                var security2 = new OpenApiSecurityRequirement()
                                {
                                    {
                                        new OpenApiSecurityScheme
                                        {
                                            Reference = new OpenApiReference
                                            {
                                                Type = ReferenceType.SecurityScheme,
                                                Id = "Bearer"
                                            },
                                            Scheme = "oauth2",
                                            Name = "Bearer",
                                            In = ParameterLocation.Header,

                                        },
                                        new List<string>()
                                    }
                                };
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
            });

            return services;
        }
    }

}
