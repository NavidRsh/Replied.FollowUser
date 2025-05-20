using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Domain.Exceptions;
public class AlreadyFollowingException : Exception
{
    public AlreadyFollowingException() : base("You are already following this user!")
    {

    }
}
