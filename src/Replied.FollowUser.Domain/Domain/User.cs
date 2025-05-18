using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Domain.Domain;
public class User : BaseEntity
{

    private User(string name, DateOnly birthDate)
    {
        this.Id = Guid.NewGuid();
        this.Name = name;
        this.BirthDate = birthDate;
    }    

    /// <summary>
    /// Name of the user
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Birth date of the user
    /// </summary>
    public DateOnly BirthDate { get; private set; }

    /// <summary>
    /// The number of followers.
    /// Storing this value improves query performance and serves as a foundation 
    /// for handling concurrency using a pessimistic approach.
    /// </summary>
    public int FollowersCount { get; private set; }


    /// <summary>
    /// The number of followings.
    /// Storing this value improves query performance and serves as a foundation 
    /// for handling concurrency using a pessimistic approach.
    /// </summary>
    public int FollowingCount { get; private set; }

    #region Collections 

    private readonly HashSet<UserFollow> _followers = new();
    
    private readonly HashSet<UserFollow> _following = new();
    
    private readonly HashSet<FollowRequest> _followRequests = new();

    private readonly HashSet<FollowRequest> _followRequested = new();

    private readonly HashSet<Blocked> _blockedUsers = new();

    private readonly HashSet<Blocked> _blockerUsers = new();

    public IReadOnlyCollection<UserFollow> Followers => _followers;

    public IReadOnlyCollection<UserFollow> Following => _following;

    public IReadOnlyCollection<FollowRequest> FollowRequests => _followRequests;

    public IReadOnlyCollection<FollowRequest> FollowRequested => _followRequested;

    public IReadOnlyCollection<Blocked> BlockedUsers => _blockedUsers;

    public IReadOnlyCollection<Blocked> BlockerUsers => _blockerUsers;

    #endregion

    public static User Create(string name, DateOnly birthDate)
    {
        return new User(name, birthDate);
    }
    
}
