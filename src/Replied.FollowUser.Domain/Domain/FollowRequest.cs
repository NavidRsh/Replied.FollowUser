using Replied.FollowUser.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Domain.Domain;
/// <summary>
/// Represents a follow request between two users, including status and timestamp.
/// </summary>
public class FollowRequest : BaseEntity
{
    private FollowRequest()
    {
        
    }
    private FollowRequest(User followee)
    {
        Followee = followee;
        Status = FollowRequestStatus.Pending;
        RequestDate = DateTime.Now;
    }

    /// <summary>
    /// The user who sent the follow request.
    /// </summary>
    public Guid FollowerId { get; private set; }
    public User Follower { get; private set; }
    /// <summary>
    /// The user to whom the follow request was sent.
    /// </summary>
    public Guid FolloweeId { get; private set; }
    public User Followee { get; private set; }
    /// <summary>
    /// The current status of the follow request (e.g., Pending, Accepted).
    /// </summary>
    public FollowRequestStatus Status { get; private set; }
    /// <summary>
    /// The date and time the follow request was made.
    /// </summary>
    public DateTime RequestDate { get; private set; }

    /// <summary>
    /// Creates a new follow request targeting the specified followee.
    /// </summary>
    public static FollowRequest Create(User Followee)
    { 
        return new FollowRequest(Followee);
    }

    /// <summary>
    /// Accepts the follow request if it is still pending.
    /// </summary>
    public void Accept()
    {
        ThrowIfRequestIsNotPending(this);

        this.Status = FollowRequestStatus.Accepted; 
    }

    /// <summary>
    /// Throws an exception if the status of the request is not pending.
    /// </summary>
    private static void ThrowIfRequestIsNotPending(FollowRequest followRequest)
    {
        if (followRequest.Status != Enums.FollowRequestStatus.Pending)        
            throw new Exception("Request status is not valid!");        
    }
}
