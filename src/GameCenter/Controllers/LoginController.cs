using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCenter.BLL;
using GameCenter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GameCenter.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private ISecurity _security;

        public LoginController(ISecurity security)
        {
            if(security == null)
                throw  new ArgumentNullException(nameof(security));

            _security = security;
        }

        [HttpPost]
        public async Task<LoginModel> Index([FromBody]LoginModel model)
        {
            var result = _security.Login(model.Login, model.Password);
            if (result.Result)
            {
                Response.Cookies.Append("_auth", result.Value.ToString());
            }

            return result;
        }
    }
}
