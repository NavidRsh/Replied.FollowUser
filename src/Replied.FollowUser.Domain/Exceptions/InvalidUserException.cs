using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Domain.Exceptions;
public class InvalidUserException : Exception
{
    public Guid UserId { get; private set; }

    public InvalidUserException(Guid userId) : base("User is invalid:" + userId)
    {
        UserId = userId;
    }
}
