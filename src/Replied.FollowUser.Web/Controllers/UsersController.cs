using MediatR;
using Microsoft.AspNetCore.Mvc;
using Replied.FollowUser.Application.Commands.FollowUser;
using Replied.FollowUser.Application.Queries.GetAllUsers;
using Replied.FollowUser.Application.Queries.GetFollowRequests;
using Replied.FollowUser.Web.ViewModels;

namespace Replied.FollowUser.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets a list of all users.
        /// </summary>
        /// <returns>A response containing all users.</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(GetAllUsersResponse), 200)]
        public async Task<ActionResult<GetAllUsersResponse>> GetAll()
        {
            var response = await _mediator.Send(new GetAllUsersQuery());

            return new ActionResult<GetAllUsersResponse>(response);
        }

        /// <summary>
        /// Sends a follow request from one user to another.
        /// </summary>
        /// <param name="request">Contains the sender and receiver user IDs.</param>
        /// <returns>A response indicating the result of the follow request operation.</returns>
        [HttpPost("SendFollowRequest")]
        public async Task<ActionResult<SendFollowRequestResponse>>
            SendFollowRequest(SendFollowRequestVM request)
        {
            var response = await _mediator.Send(
                new SendFollowReqeustCommand(request.FromUserId, request.ToUserId));

            return new ActionResult<SendFollowRequestResponse>(response);
        }

        /// <summary>
        /// Gets a list of follow requests sent to the specified user.
        /// </summary>
        /// <param name="UserId">The ID of the user to get follow requests for.</param>
        /// <returns>A list of follow requests.</returns>
        [HttpGet("GetMyFollowRequests")]
        public async Task<ActionResult<GetFollowRequestsResponse>>
            GetFollowRequest(Guid UserId)
        {
            var response = await _mediator.Send(
                new GetFollowRequestsQuery(UserId));

            return new ActionResult<GetFollowRequestsResponse>(response);
        }

        /// <summary>
        /// Accepts a follow request by ID.
        /// </summary>
        /// <param name="FollowRequestId">The ID of the follow request to accept.</param>
        /// <returns>A response indicating the result of the accept operation.</returns>
        [HttpPost("AcceptRequest")]
        public async Task<ActionResult<AcceptFollowResponse>>
            AcceptRequest(Guid FollowRequestId)
        {
            var response = await _mediator.Send(
                new AcceptFollowCommand(FollowRequestId));

            return new ActionResult<AcceptFollowResponse>(response);
        }
    }
}
