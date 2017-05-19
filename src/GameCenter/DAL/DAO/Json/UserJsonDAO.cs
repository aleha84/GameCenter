using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCenter.DAL.Entities;
using Microsoft.AspNetCore.Hosting;

namespace GameCenter.DAL.DAO.Json
{
    public class UserJsonDAO : BaseJsonDAO<User>, IUserDAO

    {
        public UserJsonDAO(IHostingEnvironment hostingEnvironment) : base(hostingEnvironment)
        {
        }

        public User GetByName(string name)
        {
            var result = _data.FirstOrDefault(x => x.Name.Equals(name));

            return (User)result?.Clone();
        }
    }
}
