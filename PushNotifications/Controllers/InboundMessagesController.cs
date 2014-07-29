using Newtonsoft.Json;
using PushNotifications.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PushNotifications.Controllers
{
    public class InboundMessagesController : ApiController
    {
        private static readonly ConcurrentQueue<StreamWriter> _streammessage = new ConcurrentQueue<StreamWriter>();

        [HttpPost]
        public void Post([FromBody]XElement xml)
        {
            StringReader reader = new StringReader(xml.ToString());
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(InboundMessage));
            var inboundMessage = (InboundMessage)xmlSerializer.Deserialize(reader);
            MessageCallback(inboundMessage);
        }

        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            HttpResponseMessage response = request.CreateResponse();

            response.Content = new PushStreamContent((Action<Stream, HttpContent, TransportContext>)OnStreamAvailable, "text/event-stream");
            return response;
        }

        private static void OnStreamAvailable(Stream stream, HttpContent headers, TransportContext context)
        {
            StreamWriter streamwriter = new StreamWriter(stream);
            _streammessage.Enqueue(streamwriter);
        }

        private static void MessageCallback(InboundMessage m)
        {
            foreach (var subscriber in _streammessage)
            {
                subscriber.WriteLine("data:" + JsonConvert.SerializeObject(m) + "\n");
                subscriber.Flush();
            }
        }
    }
}