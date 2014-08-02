using Newtonsoft.Json;
using PushNotifications.Hubs;
using PushNotifications.Models;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PushNotifications.Controllers
{
    public class DeliveredMessagesController : ApiControllerWithHub<MessagesHub>
    {
        [HttpPost]
        public HttpStatusCode Post([FromBody]XElement xml)
        {
            var reader = new StringReader(xml.ToString());
            var xmlSerializer = new XmlSerializer(typeof(MessageDelivered));
            var deliveredMessage = (MessageDelivered)xmlSerializer.Deserialize(reader);

            Hub.Clients.All.addNewDeliveredMessageToPage(deliveredMessage);
            return HttpStatusCode.OK;
        }
    }
}
