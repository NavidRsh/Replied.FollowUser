using MediatR;
using Replied.FollowUser.Application.Queries.GetAllUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Application.Commands.FollowUser;
public record SendFollowReqeustCommand(Guid FromUserId, Guid ToUserId) : IRequest<SendFollowRequestResponse>;

public record SendFollowRequestResponse(bool Success, string Message);