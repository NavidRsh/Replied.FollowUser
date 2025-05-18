using Replied.FollowUser.Application.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Infrastructure.InMemory.Repositories;
public class UserCommandRepository : IUserCommandRepository
{
    public UserCommandRepository(ApplicationDbContext dbContext)
    {
        
    }
}
