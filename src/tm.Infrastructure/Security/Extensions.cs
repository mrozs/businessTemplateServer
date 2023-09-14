using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using tm.Application.Security;
using tm.Core.Entities;

namespace tm.Infrastructure.Security;

internal static class Extensions
{
    public static IServiceCollection AddSecurity(this IServiceCollection services)
    {
        services
            .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>()
            .AddSingleton<IPasswordManager, PasswordManager>();

        return services;
    }
}
