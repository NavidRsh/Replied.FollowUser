using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Application.Services;
public interface ILockService
{
    Task GetLockAsync(Guid id, CancellationToken cancellationToken = default);

    void ReleaseLock(Guid id);

    TimeSpan? GetLockAge(Guid id);
}
