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

namespace PushNotifications.Controllers
{
    public class InboundMessagesController : ApiControllerWithHub<MessagesHub>
    {
        [HttpPost]
        public HttpStatusCode Post([FromBody]XElement xml)
        {
            var reader = new StringReader(xml.ToString());
            var xmlSerializer = new XmlSerializer(typeof(InboundMessage));
            var inboundMessage = (InboundMessage)xmlSerializer.Deserialize(reader);

            Hub.Clients.All.addNewInboundMessageToPage(inboundMessage);
            return HttpStatusCode.OK;
        }
    }
}