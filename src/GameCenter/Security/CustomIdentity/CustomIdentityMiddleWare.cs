using System;
using System.Collections.Generic;
using System.Linq;
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

            if(!request.Cookies.ContainsKey("_auth"))
                throw new WrongIdentityException("Not logged in");

            var auth = request.Cookies["_auth"];

            if(auth.IsNullOrEmpty())
                throw new WrongIdentityException("Wrong data");

            await _next(context);
        }
    }
}
