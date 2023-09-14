using Microsoft.EntityFrameworkCore;
using tm.Core.Entities;
using tm.Infrastructure.DAL.Configurations;

namespace tm.Infrastructure.DAL;

internal sealed class tmDbContext : DbContext
{
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<WeeklyParkingSpot> WeeklyParkingSpots { get; set; }
    public DbSet<User> Users { get; set; }

    public tmDbContext(DbContextOptions<tmDbContext> dbContextOptions) : base(dbContextOptions)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
