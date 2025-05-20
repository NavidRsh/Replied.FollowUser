using MediatR;
using Replied.FollowUser.Application.Contracts.Repositories;
using Replied.FollowUser.Application.Services;
using Replied.FollowUser.Domain.Domain;
using Replied.FollowUser.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Application.Commands.FollowUser;
public class SendFollowRequestCommandHandler : 
    IRequestHandler<SendFollowReqeustCommand, SendFollowRequestResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILockService _lockService;

    public SendFollowRequestCommandHandler(IUnitOfWork unitOfWork,
        ILockService lockService)
    {
        this._unitOfWork = unitOfWork;
        this._lockService = lockService;
    }

    public async Task<SendFollowRequestResponse> Handle(SendFollowReqeustCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            await _lockService.GetLockAsync(request.FromUserId, cancellationToken);

            User follower = await FetchFollowerAsync(request);

            User followee = await FetchFolloweeAsync(request);

            follower.SendFollowRequest(followee);

            await _unitOfWork.SaveChangesAsync();

            return new SendFollowRequestResponse(true, "Follow request sent!");
        }
        finally
        {
            _lockService.ReleaseLock(request.FromUserId); 
        }
    }

    private async Task<User> FetchFolloweeAsync(SendFollowReqeustCommand request)
    {
        User? followee = await _unitOfWork.Users
                    .GetIncludingBlockedAsync(request.ToUserId, request.FromUserId);

        if (followee == null)
        {
            throw new UserNotFoundException(request.FromUserId);
        }

        return followee;
    }

    private async Task<User> FetchFollowerAsync(SendFollowReqeustCommand request)
    {
        User? follower = await _unitOfWork.Users
                    .GetIncludeFollowingAsync(request.FromUserId, request.ToUserId);

        if (follower == null)
        {
            throw new UserNotFoundException(request.FromUserId);
        }

        return follower;
    }
}