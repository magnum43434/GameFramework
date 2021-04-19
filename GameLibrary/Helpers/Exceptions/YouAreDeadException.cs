using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Helpers.Exceptions
{
    public class YouAreDeadException : Exception
    {
        public YouAreDeadException(string message) : base(message)
        {
        }
    }
}