using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.BLL.Providers
{
    public class InMemorySessionProvider : ISessionProvider
    {
        private IDictionary<int, Guid> _sessions;

        public InMemorySessionProvider()
        {
            _sessions = new ConcurrentDictionary<int, Guid>();
        }


        public bool CheckSession(int userId, Guid sessionId)
        {
            return _sessions.ContainsKey(userId) && _sessions[userId].Equals(sessionId);
        }

        public void RemoveSession(int userId)
        {
            if (_sessions.ContainsKey(userId))
                _sessions.Remove(userId);
        }

        public Guid AddSession(int userId)
        {
            RemoveSession(userId);
            var sessionId = Guid.NewGuid();

            _sessions[userId] = sessionId;

            return sessionId;
        }
    }
}
