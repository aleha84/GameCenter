using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.Infrastructure.Exceptions
{
    public class WrongIdentityException : Exception
    {
        public WrongIdentityException() : base("Wrong Identity") { }
        public WrongIdentityException(string msg) : base($"Wrong Identity. {msg}") { }
    }
}
