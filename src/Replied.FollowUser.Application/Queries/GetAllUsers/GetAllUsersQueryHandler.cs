using MediatR;
using Replied.FollowUser.Application.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Application.Queries.GetAllUsers;
public class GetAllUsersQueryHandler :
    IRequestHandler<GetAllUsersQuery, GetAllUsersResponse>
{
    private readonly IUserQueryRepository _userQueryRepository;

    public GetAllUsersQueryHandler(IUserQueryRepository userQueryRepository)
    {
        this._userQueryRepository = userQueryRepository;
    }

    public async Task<GetAllUsersResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return new GetAllUsersResponse(await _userQueryRepository
            .GetAllAsync());         
    }
}
