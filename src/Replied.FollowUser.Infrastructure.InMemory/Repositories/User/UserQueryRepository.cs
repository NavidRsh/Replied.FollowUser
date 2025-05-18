using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Replied.FollowUser.Application.Contracts.Repositories;
using Replied.FollowUser.Application.Queries.GetAllUsers;
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
            .Select(a => new GetAllUsersResponseItem(a.Id, a.Name))
            .ToListAsync();
    }
}
