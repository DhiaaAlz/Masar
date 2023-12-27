using Microsoft.AspNetCore.SignalR;

namespace CyperBooking.Hubs
{
    public class MyHub : Hub
    {

        public async Task SendJsonObject()
        {
            await Clients.All.SendAsync("receiveJsonObject");
        }
        
        public async Task sendNotifi()
        {
            await Clients.All.SendAsync("getNotifi");
        }


    }
}
