using Replied.FollowUser.Application.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Application.Contracts.Repositories;
public interface IUnitOfWork
{
    public IUserCommandRepository Users{ get; }    
    void SaveChanges();
    Task SaveChangesAsync();
}
