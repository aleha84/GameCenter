using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCenter.DAL.Entities;
using GameCenter.Models;

namespace GameCenter.BLL
{
    public interface ISecurity
    {
        LoginModel Login(string login, string password);
        UserModel GetUserBySessionId(string sessionId);
    }
}
