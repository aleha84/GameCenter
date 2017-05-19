using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCenter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GameCenter.Controllers
{
    [Authorize(Policy = "loggedInOnly")]
    public class RootController : Controller
    {
        // GET: /<controller>/
        public async Task<RootModel> Index()
        {
            return new RootModel() { Message = "Hello" };
        }
    }
}
