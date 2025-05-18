using Replied.FollowUser.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Domain.Domain;
public class FollowRequest : BaseEntity
{
    public Guid FollowerId { get; private set; }
    public User Follower { get; private set; }

    public Guid FolloweeId { get; private set; }
    public User Followee { get; private set; }

    public FollowRequestStatus Status { get; private set; }

    public DateTime RequestDate { get; private set; }    
}
