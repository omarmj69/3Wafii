using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3Wafii.Hubs
{

    [HubName("OrderHub")]
    public class OrderHub : Hub
    {
        public static void BroadcastData()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<OrderHub>();
            context.Clients.All.refreshOrderData();

        }

    }
}