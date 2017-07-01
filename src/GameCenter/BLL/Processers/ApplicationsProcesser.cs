using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCenter.Models;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using GameCenter.Infrastructure.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace GameCenter.BLL.Processers
{
    public class ApplicationsProcesser : IApplicationsProcesser
    {
        private readonly IConnectionManager _connectionManager;
        private readonly IHubContext _hubContext;

        public ApplicationsProcesser(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager ?? throw new ArgumentNullException(nameof(connectionManager));
            _hubContext = _connectionManager.GetHubContext<ConversationHub>();
        }

        public void Add(ApplicationDescriptionModel application)
        {
            throw new NotImplementedException();
        }
    }
}
