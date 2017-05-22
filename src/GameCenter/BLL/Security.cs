using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameCenter.BLL.Providers;
using GameCenter.DAL.DAO;
using GameCenter.DAL.Entities;
using GameCenter.Infrastructure.Extensions;
using GameCenter.Models;

namespace GameCenter.BLL
{
    public class Security : ISecurity
    {
        private readonly IUserDAO _userDAO;
        private readonly ISessionProvider<int> _sessionProvider;
        private readonly IMapper _mapper;

        public Security(
            IUserDAO userDAO,
            ISessionProvider<int> sessionProvider,
            IMapper mapper)
        {
            if(userDAO == null)
                throw new ArgumentNullException(nameof(userDAO));

            if (sessionProvider == null)
                throw new ArgumentNullException(nameof(sessionProvider));

            if(mapper == null)
                throw new ArgumentNullException(nameof(mapper));

            _userDAO = userDAO;
            _sessionProvider = sessionProvider;
            _mapper = mapper;
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

        public UserModel GetUserBySessionId(string sessionId)
        {
            var userId = 0;
            try
            {
                userId = _sessionProvider.GetSessionValue(Guid.Parse(sessionId));
                if (userId == 0)
                    return null;
            }
            catch
            {
                return null;
            }
            
            var user = _userDAO.GetById(userId);
            if (user == null)
                return null;

            return _mapper.Map<UserModel>(user);
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
