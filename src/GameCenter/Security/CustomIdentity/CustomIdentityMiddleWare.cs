using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GameCenter.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using GameCenter.Infrastructure.Extensions;

namespace GameCenter.Security.CustomIdentity
{
    public class CustomIdentityMiddleWare
    {
        private readonly RequestDelegate _next;

        public CustomIdentityMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;

            var claims = new List<Claim>();
            var id = Guid.Empty;

            //TODO cookie name in properties
            if (!request.Cookies.ContainsKey("_auth"))
                CreateAnonymous(claims);
            else
            {
                var auth = request.Cookies["_auth"];

                if (auth.IsNullOrEmpty())
                    CreateAnonymous(claims);
                else
                {

                }
            }

            var claimsIdentity = new CustomIdentity(claims, id, "custom");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            context.User = claimsPrincipal;

            await _next(context);

            //throw new WrongIdentityException("Not logged in");
        }

        private void CreateAnonymous(IList<Claim> claims)
        {
            claims.Add(new Claim(ClaimTypes.Anonymous, "True"));
            claims.Add(new Claim(ClaimTypes.Name, "Аноним"));
        }
    }
}
