namespace tm.Infrastructure.DAL;

internal sealed class SqlUnitOfWork : IUnitOfWork
{
    private readonly tmDbContext _dbContext;

    public SqlUnitOfWork(tmDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ExecuteAsync(Func<Task> action)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            await action();
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}