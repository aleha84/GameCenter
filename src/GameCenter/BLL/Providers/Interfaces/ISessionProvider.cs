using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.BLL.Providers.Interfaces
{
    public interface ISessionProvider<T>
    {
        bool CheckSession(T userId, Guid sessionId);
        void RemoveSession(T userId);
        Guid AddSession(T userId);
        T GetSessionValue(Guid sessionId);
    }
}
