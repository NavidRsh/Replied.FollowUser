using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Application.Commands.FollowUser;
public record FollowUserCommand(Guid FromUserId, Guid ToUserId) : IRequest<bool>;