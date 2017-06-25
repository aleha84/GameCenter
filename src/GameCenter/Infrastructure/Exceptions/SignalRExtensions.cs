using Microsoft.AspNetCore.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.Infrastructure.Exceptions
{
    public static class SignalRExtensions
    {
        public static Guid IdParsed(this HubCallerContext context)
        {
            if (string.IsNullOrEmpty(context.ConnectionId))
                return Guid.Empty;

            return Guid.Parse(context.ConnectionId);
        }
    }
}
