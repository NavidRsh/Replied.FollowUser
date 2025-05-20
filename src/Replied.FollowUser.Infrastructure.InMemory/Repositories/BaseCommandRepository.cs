using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Infrastructure.InMemory.Repositories;
public class BaseCommandRepository
{
    protected readonly ApplicationDbContext _dbContext;
    public BaseCommandRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}
