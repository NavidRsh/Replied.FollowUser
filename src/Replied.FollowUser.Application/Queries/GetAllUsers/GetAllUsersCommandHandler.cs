using MediatR;
using Replied.FollowUser.Application.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Application.Queries.GetAllUsers;
public class GetAllUsersCommandHandler :
    IRequestHandler<GetAllUsersCommand, GetAllUsersResponse>
{
    private readonly IUserQueryRepository _userQueryRepository;

    public GetAllUsersCommandHandler(IUserQueryRepository userQueryRepository)
    {
        this._userQueryRepository = userQueryRepository;
    }

    public async Task<GetAllUsersResponse> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
    {
        return new GetAllUsersResponse(await _userQueryRepository
            .GetAllAsync());         
    }
}
