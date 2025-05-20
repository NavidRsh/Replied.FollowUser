using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Domain.Domain;
/// <summary>
/// Represents a follower-followee relationship between two users.
/// Can optionally track whether the follow is a 'close friend' connection.
/// </summary>
public class UserFollow : BaseEntity
{
    private UserFollow()
    {
        
    }

    public UserFollow(User follower, UserFollow? previousRelation)
    {
        Follower = follower;
        IsCloseFriend = previousRelation is not null ? true : false;
        FollowedAt = DateTime.Now;
    }

    /// <summary>
    /// The user who is following another user.
    /// </summary>
    public Guid FollowerId { get; set; }
    public User Follower { get; set; }

    /// <summary>
    /// The user being followed.
    /// </summary>
    public Guid FolloweeId { get; set; }
    public User Followee { get; set; }
    /// <summary>
    /// The date and time the follow occurred.
    /// </summary>
    public DateTime FollowedAt { get; set; } = DateTime.UtcNow;
    /// <summary>
    /// Indicates whether the follow is marked as a 'close friend'.
    /// </summary>
    public bool IsCloseFriend { get; set; }

    /// <summary>
    /// Creates a new follow relationship. Marks as close friend if a previous relation existed.
    /// </summary>
    public static UserFollow Create(User follower, UserFollow? previousRelation)
    {
        return new UserFollow(follower, previousRelation); 
    }
}
