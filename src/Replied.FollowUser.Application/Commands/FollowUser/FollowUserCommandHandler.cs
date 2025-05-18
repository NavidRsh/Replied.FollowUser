using MediatR;
using Replied.FollowUser.Application.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Application.Commands.FollowUser;
public class FollowUserCommandHandler : IRequestHandler<FollowUserCommand, bool>
{
    private readonly IUserCommandRepository _repository;

    public FollowUserCommandHandler(IUserCommandRepository repository)
    {
        _repository = repository;
    }

    public Task<bool> Handle(FollowUserCommand request, CancellationToken cancellationToken)
    {
        return null; 
    }
}