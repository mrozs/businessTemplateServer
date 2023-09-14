using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using tm.Application.Abstractions;
using tm.Core.Abstractions;
using tm.Infrastructure.Auth;
using tm.Infrastructure.DAL;
using tm.Infrastructure.DAL.Repositories;
using tm.Infrastructure.Exceptions;
using tm.Infrastructure.Logging;
using tm.Infrastructure.Security;
using tm.Infrastructure.Time;

[assembly: InternalsVisibleTo("tm.Tests.Integration")]
[assembly: InternalsVisibleTo("tm.Tests.Unit")]
namespace tm.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection("app");
        services.Configure<AppOptions>(section);
        services.AddSingleton<ExceptionMiddleware>();
        services.AddSecurity();
        services.AddAuth(configuration);
        services.AddHttpContextAccessor();

        services
            .AddSqlServer(configuration)
            .AddSingleton<IClock, Clock>();

        var infrastructureAssembly = typeof(AppOptions).Assembly;
        services.Scan(s => s.FromAssemblies(infrastructureAssembly)
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.AddCustomLogging();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(swagger =>
        {
            swagger.EnableAnnotations();
            swagger.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
            {
                Title = "tm API",
                Version = "v1",
            });
        });

        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseSwagger();
        //app.UseReDoc(redoc =>
        //{
        //    redoc.RoutePrefix = "docs";
        //    redoc.DocumentTitle = "tm API";
        //    redoc.SpecUrl("/swagger/v1/swagger.json");
        //});
        app.UseSwaggerUI();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }

    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetSection(sectionName);
        section.Bind(options);

        return options;
    }
}
