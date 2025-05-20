using MediatR;
using Replied.FollowUser.Application.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Application.Queries.GetFollowRequests;
public class GetFollowRequestsQueryHandler : IRequestHandler<GetFollowRequestsQuery,
    GetFollowRequestsResponse>
{
    private readonly IUserQueryRepository _userQueryRepository;

    public GetFollowRequestsQueryHandler(IUserQueryRepository userQueryRepository)
    {
        this._userQueryRepository = userQueryRepository;
    }
    public async Task<GetFollowRequestsResponse> Handle(GetFollowRequestsQuery request,
        CancellationToken cancellationToken)
    {
        return new GetFollowRequestsResponse(await 
            _userQueryRepository.GetUserFollowRequestsAsync(request.UserId)); 
    }
}
