using MediatR;
using Replied.FollowUser.Application.Queries.GetAllUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Application.Queries.GetFollowRequests;
public record GetFollowRequestsQuery(Guid UserId) : IRequest<GetFollowRequestsResponse>;

public record GetFollowRequestsResponse(IEnumerable<GetFollowRequestsResponseItem> Items);

public record GetFollowRequestsResponseItem(Guid RequestId, Guid FromUserId, string FromUserName);
