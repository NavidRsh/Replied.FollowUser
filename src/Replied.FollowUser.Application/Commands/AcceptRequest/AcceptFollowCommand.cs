using MediatR;
using Replied.FollowUser.Application.Queries.GetAllUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Application.Commands.FollowUser;
public record AcceptFollowCommand(Guid FollowRequestId) 
    : IRequest<AcceptFollowResponse>;

public record AcceptFollowResponse(bool Success, string Message);