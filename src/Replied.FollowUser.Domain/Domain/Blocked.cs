using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Domain.Domain;
/// <summary>
/// Represents a blocked relationship where one user has blocked another.
/// </summary>
public class Blocked : BaseEntity
{
    /// <summary>
    /// The user who initiated the block.
    /// </summary>
    public Guid UserId { get; private set; }
    public User User { get; private set; }

    /// <summary>
    /// The user who was blocked.
    /// </summary>
    public Guid BlockedUserId { get; private set; }
    public User BlockedUser { get; private set; }

    /// <summary>
    /// The date and time when the block was applied.
    /// </summary>
    public DateTime BlockedTime { get; private set; }
}
