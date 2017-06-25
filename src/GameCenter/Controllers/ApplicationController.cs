using GameCenter.BLL;
using GameCenter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GameCenter.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "loggedInOnly")]
    public class ApplicationController : Controller
    {
        private readonly IApplicationsBLL _applicationsBLL;

        public ApplicationController(IApplicationsBLL applicationsBLL)
        {
            _applicationsBLL = applicationsBLL ?? throw new ArgumentNullException(nameof(applicationsBLL));
        }

        [HttpGet("{id}")]
        public async Task<ApplicationDescriptionModel> GetDescription(int id)
        {
            if (id <= 0)
                return null;

            return _applicationsBLL.GetById(id);
        }
    }
}
