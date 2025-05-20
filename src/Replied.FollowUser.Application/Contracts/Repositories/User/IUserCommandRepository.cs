using Replied.FollowUser.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Application.Contracts.Repositories;
public interface IUserCommandRepository
{
    Task<User?> GetUserByIdAsync(Guid id);

    Task<User?> GetIncludeFollowingAsync(Guid id, Guid followingId);

    Task<User?> GetIncludingBlockedAsync(Guid id, Guid followerId);

    Task<FollowRequest?> GetFollowRequest(Guid followRequestId);

    Task<UserFollow?> GetUserFollowAsync(Guid followerId, Guid followeeId); 
}
