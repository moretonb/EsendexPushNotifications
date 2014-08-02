using PushNotifications.Hubs;
using PushNotifications.Models;
using System.Net;
using System.Web.Http;

namespace PushNotifications.Controllers
{
    public class AppMessagesController : ApiControllerWithHub<MessagesHub>
    {
        [HttpPost]
        public HttpStatusCode Post(AccountEventHandlerOptions message)
        {
            Hub.Clients.All.addNewAppMessageToPage(message);
            return HttpStatusCode.OK;
        }
    }
}