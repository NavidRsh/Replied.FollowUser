using Replied.FollowUser.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Domain.Domain;
/// <summary>
/// Represents a user within the social system, including their personal information,
/// follow relationships, follow requests, and blocking status.
/// </summary>
public class User : BaseEntity
{
    private User(string name, DateOnly birthDate)
    {
        this.Id = Guid.NewGuid();
        this.Name = name;
        this.BirthDate = birthDate;
    }

    private User(Guid id, string name, DateOnly birthDate)
    {
        this.Id = id;
        this.Name = name;
        this.BirthDate = birthDate;
    }

    #region Attributes
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

    /// <summary>
    /// The total number of following requests.
    /// Storing this value improves query performance and serves as a foundation 
    /// for handling concurrency using a pessimistic approach.
    /// </summary>
    public int FollowingRequestsCount { get; private set; }

    #endregion

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

    #region Overrides 
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;

        if (obj is null || GetType() != obj.GetType())
            return false;

        var other = (User)obj;
        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    #endregion

    #region Factories 
    /// <summary>
    /// Creates a new user with a specified name and birth date.
    /// </summary>
    public static User Create(string name, DateOnly birthDate)
    {
        return new User(name, birthDate);
    }
    /// <summary>
    /// Creates a new user with an existing ID, name, and birth date.
    /// Useful for loading users from persistence.
    /// </summary>
    public static User Create(Guid id, string name, DateOnly birthDate)
    {
        return new User(id, name, birthDate);
    }
    #endregion

    #region Methods 
    /// <summary>
    /// Sends a follow request to the specified user, performing all required validations.
    /// </summary>
    /// <param name="followee">The user to follow.</param>
    public void SendFollowRequest(User followee)
    {
        ValidateSendingFollowRequest(followee);

        _followRequests.Add(FollowRequest.Create(followee));

        this.FollowingRequestsCount++;
    }

    /// <summary>
    /// Accepts a follow request and updates user relationships accordingly.
    /// </summary>
    /// <param name="followRequest">The incoming follow request.</param>
    /// <param name="previousRelation">An optional existing relation to retain 'close friend' status.</param>
    public void AcceptFollowRequest(FollowRequest followRequest, 
        UserFollow? previousRelation)
    {
        followRequest.Accept();

        this._followers.Add(UserFollow.Create(followRequest.Follower, previousRelation));

        this.FollowersCount++;

        followRequest.Follower.FollowingCount++;

        if (previousRelation is not null)        
            previousRelation.IsCloseFriend = true;         
    }

    /// <summary>
    /// Validates whether a follow request can be sent to the specified user.
    /// </summary>
    private void ValidateSendingFollowRequest(User followee)
    {
        ThrowIfSelfFollow(followee);

        ThrowIfAlreadyFollowing(followee);

        ThrowIfHasAnotherRequest(followee);

        ThrowIfFollowerIsBlocked(followee);
    }

    /// <summary>
    /// Throws an exception if the user is trying to follow themselves.
    /// </summary>
    private void ThrowIfSelfFollow(User followee)
    {
        if (this == followee)
            throw new InvalidUserException(followee.Id);
    }

    /// <summary>
    /// Throws an exception if the followee has blocked the current user.
    /// </summary>
    private void ThrowIfFollowerIsBlocked(User followee)
    {
        if (followee.HasBlockedUser(this))
        {
            throw new UserBlockedException();
        }
    }

    /// <summary>
    /// Throws an exception if a request has already been sent to the followee.
    /// </summary>
    private void ThrowIfHasAnotherRequest(User followee)
    {
        if (HasAnotherRequest(followee))
        {
            throw new RequestAlreadySentException();
        }
    }

    /// <summary>
    /// Throws an exception if the current user is already following the followee.
    /// </summary>
    private void ThrowIfAlreadyFollowing(User followee)
    {
        if (IsFollowingUser(followee))
        {
            throw new AlreadyFollowingException();
        }
    }

    /// <summary>
    /// Checks if this user is already following the specified user.
    /// </summary>
    public bool IsFollowingUser(User followee)
    {
        return _following.Any(a => a.Followee == followee); 
    }

    /// <summary>
    /// Checks if a follow request to the specified user already exists.
    /// </summary>
    public bool HasAnotherRequest(User followee)
    {
        return _followRequests.Any(a => a.Followee == followee);
    }

    /// <summary>
    /// Determines if this user has blocked the specified follower.
    /// </summary>
    public bool HasBlockedUser(User follower)
    { 
        return _blockedUsers.Any(a => a.BlockedUser == follower);
    }
    #endregion

}
