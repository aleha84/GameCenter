using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCenter.BLL;
using GameCenter.Models;
using GameCenter.Security.CustomIdentity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GameCenter.Controllers
{
    [Authorize(Policy = "loggedInOnly")]
    public class RootController : Controller
    {
        private readonly IApplicationsBLL _applicationsBLL;

        public RootController(IApplicationsBLL applicationsBLL)
        {
            if(applicationsBLL == null)
                throw new ArgumentNullException(nameof(applicationsBLL));

            _applicationsBLL = applicationsBLL;
        }

        // GET: /<controller>/
        public async Task<RootModel> Index()
        {

            return new RootModel()
            {
                User = new UserModel
                {
                    Name = ((CustomIdentity)User.Identity).Name,
                    Id = ((CustomIdentity)User.Identity).Id
                },
                Applications = _applicationsBLL.GetAll()
            };
        }
    }
}
