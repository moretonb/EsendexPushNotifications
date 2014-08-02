using Newtonsoft.Json;
using PushNotifications.Models;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;
using System.Xml.Serialization;
using PushNotifications.Hubs;
using Newtonsoft.Json.Linq;
using System.Net.Http.Formatting;

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