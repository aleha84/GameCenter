using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCenter.Models;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using GameCenter.Infrastructure.SignalR;
using Microsoft.AspNetCore.SignalR;
using GameCenter.Applications;
using System.Collections.Concurrent;

namespace GameCenter.BLL.Processers
{
    public class ApplicationsProcesser : IApplicationsProcesser
    {
        private readonly IConnectionManager _connectionManager;
        private readonly IHubContext _hubContext;

        private IDictionary<Guid, IApplication> activeApplications;

        public ApplicationsProcesser(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager ?? throw new ArgumentNullException(nameof(connectionManager));
            _hubContext = _connectionManager.GetHubContext<ConversationHub>();

            activeApplications = new ConcurrentDictionary<Guid, IApplication>();
        }

        public void Add(ApplicationDescriptionModel application, Guid creatorConnectionId)
        {
            throw new NotImplementedException();
        }
    }
}
