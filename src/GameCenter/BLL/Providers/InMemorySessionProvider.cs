using GameCenter.BLL.Providers.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.BLL.Providers
{
    public class InMemorySessionProvider<T> : ISessionProvider<T>
    {
        private IDictionary<Guid, T> _sessions;

        public InMemorySessionProvider()
        {
            _sessions = new ConcurrentDictionary<Guid, T>();
        }


        public bool CheckSession(T userId, Guid sessionId)
        {
            return _sessions.ContainsKey(sessionId) && _sessions[sessionId].Equals(userId);
        }

        public void RemoveSession(T userId)
        {
            var sessionId = _sessions.FirstOrDefault(x => x.Value.Equals(userId)).Key;
            if (!sessionId.Equals(Guid.Empty))
                _sessions.Remove(sessionId);
        }

        public Guid AddSession(T userId)
        {
            RemoveSession(userId);
            var sessionId = Guid.NewGuid();

            _sessions[sessionId] = userId;

            return sessionId;
        }

        public T GetSessionValue(Guid sessionId)
        {
            if (_sessions.ContainsKey(sessionId))
                return _sessions[sessionId];

            return default(T);
        }
    }
}
