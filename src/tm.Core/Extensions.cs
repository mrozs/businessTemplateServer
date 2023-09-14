﻿using Microsoft.Extensions.DependencyInjection;
using tm.Core.DomainServices;
using tm.Core.Policies;

namespace tm.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddSingleton<IReservationPolicy, RegularEmployeeReservationPolicy>();
        services.AddSingleton<IReservationPolicy, ManagerReservationPolicy>();
        services.AddSingleton<IReservationPolicy, BossReservationPolicy>();
        services.AddSingleton<IParkingReservationService, ParkingReservationService>();
        return services;
    }
}
