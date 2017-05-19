using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.BLL.Providers
{
    public interface ISessionProvider
    {
        bool CheckSession(int userId, Guid sessionId);
        void RemoveSession(int userId);
        Guid AddSession(int userId);
    }
}
