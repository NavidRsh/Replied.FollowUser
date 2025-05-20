using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Infrastructure.InMemory.Repositories;
public class BaseQueryRepository
{
    protected readonly ApplicationDbContext _dbContext;
    public BaseQueryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;       
    }
}

