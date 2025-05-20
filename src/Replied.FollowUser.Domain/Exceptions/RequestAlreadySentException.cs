using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Domain.Exceptions;
public class RequestAlreadySentException : Exception
{
    public RequestAlreadySentException() : base("You have another active request!")
    {

    }
}
