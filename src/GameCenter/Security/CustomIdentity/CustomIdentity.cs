using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GameCenter.Security.CustomIdentity
{
    public class CustomIdentity : ClaimsIdentity
    {
        public int Id { get; set; }

        public CustomIdentity(IEnumerable<Claim> claims, int id, string authenticationType) : base(claims, authenticationType)
        {
            this.Id = id;
        }
    }
}
