using System;
using Microsoft.EntityFrameworkCore;
using tm.Infrastructure.DAL;

namespace tm.Tests.Integration;

internal sealed class TestDatabase : IDisposable
{
    public tmDbContext Context { get; }

    public TestDatabase()
    {
        var options = new OptionsProvider().Get<SqlServerOptions>("database");
        Context = new tmDbContext(new DbContextOptionsBuilder<tmDbContext>().UseSqlServer(options.ConnectionString).Options);
    }

    public void Dispose()
    {
        Context.Database.EnsureDeleted();
        Context.Dispose();
    }
}