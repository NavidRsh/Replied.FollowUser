using Microsoft.EntityFrameworkCore;
using Replied.FollowUser.Application.Contracts.Repositories;
using Replied.FollowUser.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Infrastructure.InMemory.Repositories;
public class UserCommandRepository : BaseCommandRepository, IUserCommandRepository
{
    public UserCommandRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetIncludeFollowingAsync(Guid id, Guid followingId)
    { 
        return await _dbContext.Users.Where(u => u.Id == id)
            .Include(u => u.Following.Where(f => f.FolloweeId == followingId))
            .Include(u => u.FollowRequests.Where(f => f.FolloweeId == followingId))
            .FirstOrDefaultAsync();
    }

    public async Task<User?> GetIncludingBlockedAsync(Guid id, Guid followerId)
    {
        return await _dbContext.Users.Where(u => u.Id == id)
            .Include(u => u.BlockedUsers.Where(f => f.BlockedUserId == followerId))            
            .FirstOrDefaultAsync();
    }

    public async Task<FollowRequest?> GetFollowRequest(Guid followRequestId)
    {
        return await _dbContext.FollowRequests
            .Where(a => a.Id == followRequestId)
            .Include(a => a.Followee)
            .Include(a => a.Follower)
            .FirstOrDefaultAsync(); 
            
    }

    public async Task<UserFollow?> GetUserFollowAsync(Guid followerId, Guid followeeId)
    { 
        return await _dbContext.UserFollows
            .Where(a => a.FollowerId == followerId && a.FolloweeId == followeeId)
            .FirstOrDefaultAsync();
    }

}
