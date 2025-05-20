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
/// <summary>
/// Handles the command to accept a follow request.
/// </summary>
public class AcceptFollowCommandHandler : 
    IRequestHandler<AcceptFollowCommand, AcceptFollowResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILockService _lockService;

    public AcceptFollowCommandHandler(IUnitOfWork unitOfWork,
        ILockService lockService)
    {
        this._unitOfWork = unitOfWork;
        this._lockService = lockService;
    }

    /// <summary>
    /// Handles the accept follow command: fetches the request, checks existing relations,
    /// acquires a lock, processes the follow acceptance, and commits the transaction.
    /// </summary>
    public async Task<AcceptFollowResponse> Handle(AcceptFollowCommand request,
        CancellationToken cancellationToken)
    {
        FollowRequest followRequest = await FetchFollowRequest(request);

        UserFollow? previousRelation = await FetchUserFollow(followRequest);

        try
        {
            await _lockService.GetLockAsync(followRequest.FolloweeId, cancellationToken);

            followRequest.Followee
                .AcceptFollowRequest(followRequest, previousRelation);

            await _unitOfWork.SaveChangesAsync();

            return new AcceptFollowResponse(true, "Accepted the follow request!");
        }
        finally
        {
            _lockService.ReleaseLock(followRequest.Followee.Id);
        }
    }

    /// <summary>
    /// Retrieves the follow request from the repository. Throws an exception if not found.
    /// </summary>
    private async Task<FollowRequest> FetchFollowRequest(AcceptFollowCommand request)
    {
        FollowRequest? followRequest = await _unitOfWork.Users
                    .GetFollowRequest(request.FollowRequestId);

        if (followRequest is null)
            throw new Exception("Follow request not found!");

        return followRequest; 
    }

    /// <summary>
    /// Retrieves an existing follow relationship between the follower and followee if any.
    /// </summary>
    private async Task<UserFollow?> FetchUserFollow(FollowRequest followRequest)
    {
        return await _unitOfWork.Users
                .GetUserFollowAsync(followRequest.FolloweeId, followRequest.FollowerId);       
    }
    
}