using MediatR;
using Microsoft.AspNetCore.Mvc;
using Replied.FollowUser.Application.Commands.FollowUser;
using Replied.FollowUser.Application.Queries.GetAllUsers;

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

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(GetAllUsersResponse), 200)]
        public async Task<ActionResult<GetAllUsersResponse>> GetAll()
        {
            var result = await _mediator.Send(new GetAllUsersCommand());
            return new ActionResult<GetAllUsersResponse>(result);
        }

        [HttpPost("{fromId}/follow/{toId}")]
        public async Task<IActionResult> Follow(Guid fromId, Guid toId)
        {
            var success = await _mediator.Send(new FollowUserCommand(fromId, toId));
            return success ? Ok() : Forbid();
        }
    }
}
