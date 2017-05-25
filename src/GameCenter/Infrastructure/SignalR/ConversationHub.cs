using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace GameCenter.Infrastructure.SignalR
{
    public class ConversationHub : Hub
    {
        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }

        public async Task Test()
        {
            var foo = "bar";
        }
    }
}
