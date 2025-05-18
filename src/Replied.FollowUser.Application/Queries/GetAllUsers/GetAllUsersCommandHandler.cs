using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Application.Queries.GetAllUsers;
public class GetAllUsersCommandHandler :
    IRequestHandler<GetAllUsersCommand, GetAllUsersResponse>
{
    public Task<GetAllUsersResponse> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
