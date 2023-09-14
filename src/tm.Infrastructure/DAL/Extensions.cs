using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using tm.Application.Abstractions;
using tm.Application.Commands;
using tm.Core.Repositories;
using tm.Infrastructure.DAL.Decorators;
using tm.Infrastructure.DAL.Repositories;

namespace tm.Infrastructure.DAL;

internal static class Extensions
{
    private const string SectionName = "database";

    public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection(SectionName);
        services.Configure<SqlServerOptions>(section);
        var options = configuration.GetOptions<SqlServerOptions>(SectionName);

        services.AddDbContext<tmDbContext>(x => x.UseSqlServer(options.ConnectionString));
        services.AddScoped<IWeeklyParkingSpotRepository, SqlWeeklyParkingSpotRepository>();
        services.AddScoped<IUnitOfWork, SqlUnitOfWork>();
        services.TryDecorate(typeof(ICommandHandler<>), typeof(UnitOfWorkCommandHandlerDecorator<>));
        services.AddScoped<IUserRepository, SqlServerUserRepository>();
        services.AddHostedService<DatabaseInitializer>();

        return services;
    }
}
