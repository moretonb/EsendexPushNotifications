using PushNotifications.Hubs;
using PushNotifications.Models;
using System.Net;
using System.Web.Http;

namespace PushNotifications.Controllers
{
    public class OptOutController : ApiControllerWithHub<MessagesHub>
    {
        [HttpPost]
        public HttpStatusCode Post(OptOut message)
        {
            Hub.Clients.All.addOptOutToPage(message);
            return HttpStatusCode.OK;
        }
    }
}