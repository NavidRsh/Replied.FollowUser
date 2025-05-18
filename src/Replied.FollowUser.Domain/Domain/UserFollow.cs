using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Domain.Domain;
public class UserFollow : BaseEntity
{
    public Guid FollowerId { get; set; }
    public User Follower { get; set; }

    public Guid FolloweeId { get; set; }
    public User Followee { get; set; }

    public DateTime FollowedAt { get; set; } = DateTime.UtcNow;
    public bool IsCloseFriend { get; set; }
}
