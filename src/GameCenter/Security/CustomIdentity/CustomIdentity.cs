using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GameCenter.Security.CustomIdentity
{
    public class CustomIdentity : ClaimsIdentity
    {
        public Guid Id { get; set; }

        public CustomIdentity(IEnumerable<Claim> claims, Guid Id, string authenticationType) : base(claims, authenticationType)
        {
            this.Id = Id;
        }
    }
}
