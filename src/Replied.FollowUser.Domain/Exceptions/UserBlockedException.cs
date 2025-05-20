using Replied.FollowUser.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Domain.Exceptions;
public class UserBlockedException : Exception
{
    public UserBlockedException() : base("You are blocked by this user!")
    {
        
    }
}
