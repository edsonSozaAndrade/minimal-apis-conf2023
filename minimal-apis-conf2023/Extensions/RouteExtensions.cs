﻿using minimal_apis_conf2023.Interfaces;
using System.Reflection;

namespace minimal_apis_conf2023.Extensions
{
    public static class RouteExtensions
    {
        public static IServiceCollection AddEndpoints(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblies(Assembly.GetExecutingAssembly())
                .AddClasses(classes => classes.AssignableTo<IEndpoint>())
                .AsImplementedInterfaces()
                .WithTransientLifetime()
            );

            return services;
        }

        public static WebApplication MapEndpoints(this WebApplication app)
        {
            var endpoints = app.Services.GetServices<IEndpoint>();

            foreach (var endpoint in endpoints)
            {
                endpoint.MapEndpoint(app);
            }

            return app;
        }
    }
}
