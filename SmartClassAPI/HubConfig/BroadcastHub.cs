using Microsoft.AspNetCore.SignalR;
using SmartClassAPI.Data;
using SmartClassAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartClassAPI.HubConfig
{
    public class BroadcastHub : Hub<IHubClient>
    {

    }
}
