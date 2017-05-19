using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCenter.BLL.Providers;
using GameCenter.DAL.DAO;
using GameCenter.Infrastructure.Extensions;
using GameCenter.Models;

namespace GameCenter.BLL
{
    public class Security : ISecurity
    {
        private readonly IUserDAO _userDAO;
        private readonly ISessionProvider _sessionProvider;

        public Security(
            IUserDAO userDAO,
            ISessionProvider sessionProvider)
        {
            if(userDAO == null)
                throw new ArgumentNullException(nameof(userDAO));

            if (sessionProvider == null)
                throw new ArgumentNullException(nameof(sessionProvider));

            _userDAO = userDAO;
            _sessionProvider = sessionProvider;
        }
        public LoginModel Login(string login, string password)
        {
            if (login.IsNullOrEmpty() || password.IsNullOrEmpty())
                return PrepareFailedResult(login);

            var user = _userDAO.GetByName(login);

            if(user == null || !user.Password.Equals(password))
                return PrepareFailedResult(login);

            var sessionId = _sessionProvider.AddSession(user.Id);

            return new LoginModel
            {
                Result = true,
                Value = sessionId
            };
        }

        private LoginModel PrepareFailedResult(string login)
        {
            var result = new LoginModel
            {
                Result = false,
                Login = login,
                Password = string.Empty,
                Message = "Wrong login or password"
            };

            return result;
        }
    }
}
