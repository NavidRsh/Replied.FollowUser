using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Application.Queries.GetAllUsers;
public record GetAllUsersQuery() : IRequest<GetAllUsersResponse>;

public record GetAllUsersResponse(IEnumerable<GetAllUsersResponseItem> Items);

public record GetAllUsersResponseItem(Guid Id, string Name, 
    int NumberOfFollowers, int NumberOfFollowees); 

