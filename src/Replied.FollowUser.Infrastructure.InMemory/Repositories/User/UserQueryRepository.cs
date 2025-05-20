using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Replied.FollowUser.Application.Contracts.Repositories;
using Replied.FollowUser.Application.Queries.GetAllUsers;
using Replied.FollowUser.Application.Queries.GetFollowRequests;
using Replied.FollowUser.Domain.Domain;

namespace Replied.FollowUser.Infrastructure.InMemory.Repositories;
public class UserQueryRepository : BaseQueryRepository, IUserQueryRepository
{
    public UserQueryRepository(ApplicationDbContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<GetAllUsersResponseItem>> GetAllAsync()
    { 
        return await _dbContext.Users
            .Select(a => new GetAllUsersResponseItem(a.Id, a.Name, 
            a.FollowersCount, a.FollowingCount))
            .ToListAsync();
    }

    public async Task<IEnumerable<GetFollowRequestsResponseItem>> 
        GetUserFollowRequestsAsync(Guid userId)
    {
        return await _dbContext.FollowRequests
            .Where(a => a.FolloweeId == userId)
            .Select(a => new GetFollowRequestsResponseItem(
                a.Id, a.FollowerId, a.Follower.Name))
            .ToListAsync();
    }
}
