using Replied.FollowUser.Application.Contracts.Repositories;

namespace Replied.FollowUser.Infrastructure.InMemory.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    private bool _disposed;
    public IUserCommandRepository Users =>
        new UserCommandRepository(_dbContext);


    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;        
    }
    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
