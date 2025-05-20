using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Replied.FollowUser.Application.Services;
/// <summary>
/// For scalable and distributed applications, it's generally 
/// better to use a distributed locking mechanism 
/// (e.g., Redis or database-backed locks) to ensure 
/// consistency across multiple instances. 
/// However, in our case, to keep the application simpler 
/// and avoid introducing third-party dependencies, 
/// I have implemented a lightweight in-memory lock 
/// that works reliably within a single application instance.
/// </summary>
public class InternalLockService : ILockService
{
    private readonly ConcurrentDictionary<Guid, DateTime> _currentLocks = new();
    private readonly int _lockTryCount = 5;
    private readonly int _lockRetryDelayMs = 100;

    public async Task GetLockAsync(Guid id, CancellationToken cancellationToken = default)
    {
        for (int attempt = 0; attempt < _lockTryCount; attempt++)
        {
            if (_currentLocks.TryAdd(id, DateTime.UtcNow))
            {
                return;
            }

            await Task.Delay(_lockRetryDelayMs, cancellationToken);
        }

        throw new TimeoutException($"Could not acquire lock for {id} after {_lockTryCount} retries.");
    }

    public void ReleaseLock(Guid id)
    {
        _currentLocks.TryRemove(id, out _);
    }

    public TimeSpan? GetLockAge(Guid id)
    {
        return _currentLocks.TryGetValue(id, out var acquiredTime)
            ? DateTime.UtcNow - acquiredTime
            : null;
    }
}
