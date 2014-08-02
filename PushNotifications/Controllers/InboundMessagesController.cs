using PushNotifications.Hubs;
using PushNotifications.Models;
using System.Net;
using System.Web.Http;

namespace PushNotifications.Controllers
{
    public class InboundMessagesController : ApiControllerWithHub<MessagesHub>
    {
        [HttpPost]
        public HttpStatusCode Post(InboundMessage message)
        {
            Hub.Clients.All.addNewInboundMessageToPage(message);
            return HttpStatusCode.OK;
        }
    }
}