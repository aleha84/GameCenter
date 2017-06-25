using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.BLL.Providers.Interfaces
{
    public interface IConnectionsProvider
    {
        void AddConnectionToUser(int userId, Guid connectionId);
        void RemoveConnectionFromUser(int userId, Guid connectionId);
        int GetUserIdByConnectionId(Guid connectionId);
        IEnumerable<Guid> GetConnectionsByUserId(int userId);
    }
}
