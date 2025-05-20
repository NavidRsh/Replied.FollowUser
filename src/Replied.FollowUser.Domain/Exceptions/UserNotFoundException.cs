using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Domain.Exceptions;
public class UserNotFoundException : Exception
{
    public Guid UserId { get; private set; }
    public UserNotFoundException(Guid userId): base("User Not Found!")
    {
        UserId = userId; 
    }
}
