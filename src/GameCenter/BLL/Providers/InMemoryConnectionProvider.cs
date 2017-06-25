using GameCenter.BLL.Providers.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.BLL.Providers
{
    public class InMemoryConnectionsProvider : IConnectionsProvider
    {
        private IDictionary<int, IList<Guid>> _connections;

        public InMemoryConnectionsProvider()
        {
            _connections = new ConcurrentDictionary<int, IList<Guid>>();
        }

        public void AddConnectionToUser(int userId, Guid connectionId)
        {
            if (!_connections.ContainsKey(userId))
                _connections[userId] = new List<Guid>();

            if (!_connections[userId].Any(g => g.Equals(connectionId)))
                _connections[userId].Add(connectionId);
        }

        public IEnumerable<Guid> GetConnectionsByUserId(int userId)
        {
            if (!_connections.ContainsKey(userId))
                return null;

            return _connections[userId];
        }

        public int GetUserIdByConnectionId(Guid connectionId)
        {
            return _connections.FirstOrDefault(x => x.Value.Any(c => c.Equals(connectionId))).Key;
            
        }

        public void RemoveConnectionFromUser(int userId, Guid connectionId)
        {
            if (!_connections.ContainsKey(userId) || !_connections[userId].Any(c => c.Equals(connectionId)))
                return;

            _connections[userId].Remove(connectionId);
        }
    }
}
