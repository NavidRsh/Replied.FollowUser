using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Domain.Domain;
public class User
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public DateOnly BirthDate { get; private set; }

    private readonly HashSet<UserFollow> _followers = new();
    
    private readonly HashSet<UserFollow> _following = new();
    
    private readonly HashSet<Guid> _followRequests = new();

    private readonly HashSet<Guid> _blockedUsers = new();

    public IReadOnlyCollection<UserFollow> Followers => _followers;
    public IReadOnlyCollection<UserFollow> Following => _following;
    public IReadOnlyCollection<Guid> FollowRequests => _followRequests;
    public IReadOnlyCollection<Guid> BlockedUsers => _blockedUsers;
}
