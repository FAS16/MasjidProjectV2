using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace MasjidProjectV2.Hubs
{
    public class UserHub:Hub
    {
        static long counter = 0;

        public override Task OnConnected()
        {
            counter += 1;
            Clients.All.UpdateCount(counter);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            counter -= 1;
            Clients.All.UpdateCount(counter);
            return base.OnDisconnected(stopCalled);
        }
    }
}