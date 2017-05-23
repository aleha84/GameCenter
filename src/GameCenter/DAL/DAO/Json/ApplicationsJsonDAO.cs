using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCenter.DAL.Entities;
using Microsoft.AspNetCore.Hosting;

namespace GameCenter.DAL.DAO.Json
{
    public class ApplicationsJsonDAO : BaseJsonDAO<ApplicationDescription>, IApplicationsDAO
    {
        public ApplicationsJsonDAO(IHostingEnvironment hostingEnvironment) : base(hostingEnvironment)
        {
        }
    }
}
