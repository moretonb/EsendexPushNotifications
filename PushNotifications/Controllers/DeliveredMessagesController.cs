using PushNotifications.Hubs;
using PushNotifications.Models;
using System.Net;
using System.Web.Http;

namespace PushNotifications.Controllers
{
    public class DeliveredMessagesController : ApiControllerWithHub<MessagesHub>
    {
        [HttpPost]
        public HttpStatusCode Post(MessageDelivered message)
        {
            Hub.Clients.All.addNewDeliveredMessageToPage(message);
            return HttpStatusCode.OK;
        }
    }
}
