using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using tm.Core.Entities;
using tm.Infrastructure.Time;
using Microsoft.Extensions.Hosting;
using tm.Core.ValueObjects;
using Microsoft.Extensions.DependencyInjection;

namespace tm.Infrastructure.DAL
{
    internal sealed class DatabaseInitializer : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public DatabaseInitializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<tmDbContext>();
                dbContext.Database.Migrate();

                var weeklyParkingSpots = dbContext.WeeklyParkingSpots.ToList();
                if (!weeklyParkingSpots.Any())
                {
                    var clock = new Clock();
                    weeklyParkingSpots = new List<WeeklyParkingSpot>() {
                        WeeklyParkingSpot.Create(Guid.Parse("00000000-0000-0000-0000-000000000001"), new Week(clock.Current()), "P1"),
                        WeeklyParkingSpot.Create(Guid.Parse("00000000-0000-0000-0000-000000000002"), new Week(clock.Current()), "P2"),
                        WeeklyParkingSpot.Create(Guid.Parse("00000000-0000-0000-0000-000000000003"), new Week(clock.Current()), "P3"),
                        WeeklyParkingSpot.Create(Guid.Parse("00000000-0000-0000-0000-000000000004"), new Week(clock.Current()), "P4"),
                        WeeklyParkingSpot.Create(Guid.Parse("00000000-0000-0000-0000-000000000005"), new Week(clock.Current()), "P5")
                    };
                    dbContext.AddRange(weeklyParkingSpots);
                    dbContext.SaveChanges();
                }
            }

            return Task.CompletedTask;
        }

            public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
        }

    }


