using Replied.FollowUser.Application.Queries.GetAllUsers;
using Replied.FollowUser.Application.Queries.GetFollowRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Application.Contracts.Repositories;
public interface IUserQueryRepository
{
    Task<IEnumerable<GetAllUsersResponseItem>> GetAllAsync();

    Task<IEnumerable<GetFollowRequestsResponseItem>> GetUserFollowRequestsAsync(Guid id); 
}
