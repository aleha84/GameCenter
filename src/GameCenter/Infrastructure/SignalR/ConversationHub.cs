using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using System;
using GameCenter.Infrastructure.Exceptions;
using GameCenter.Security.CustomIdentity;
using GameCenter.BLL.Providers.Interfaces;

namespace GameCenter.Infrastructure.SignalR
{
    public class ConversationHub : Hub
    {
        private readonly IConnectionsProvider _connectionProvider;

        public ConversationHub(IConnectionsProvider connectionProvider)
        {
            _connectionProvider = connectionProvider ?? throw new ArgumentNullException(nameof(connectionProvider));
        }

        public override async Task OnConnected()
        {
            var identity = ValidateContextUser();
            var id = Context.IdParsed();
            if(!id.Equals(Guid.Empty))
                _connectionProvider.AddConnectionToUser(identity.Id, id);

            await base.OnConnected();
        }

        public override async Task OnDisconnected(bool stopCalled)
        {
            var identity = ValidateContextUser();
            var id = Context.IdParsed();
            if (!id.Equals(Guid.Empty))
                _connectionProvider.RemoveConnectionFromUser(identity.Id, id);

            await base.OnDisconnected(stopCalled);
        }

        public async Task Test()
        {
            var foo = "bar";
            Clients.Caller.fakeMethod();
        }

        private CustomIdentity ValidateContextUser()
        {
            if (Context.User == null || Context.User.Identity == null)
                throw new WrongIdentityException("Hub user is null");

            var identity = Context.User.Identity as CustomIdentity;

            if (identity == null || identity.Id == 0)
                throw new WrongIdentityException("Hub user is null");

            return identity;
        }
    }
}
