using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Domain.Domain;
public class Blocked : BaseEntity
{
    public Guid UserId { get; private set; }
    public User User { get; private set; }

    public Guid BlockedUserId { get; private set; }
    public User BlockedUser { get; private set; }

    public DateTime BlockedTime { get; private set; }
}
