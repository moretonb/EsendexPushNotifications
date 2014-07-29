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

namespace PushNotifications.Controllers
{
    public class InboundMessagesController : ApiController
    {
        private static readonly ConcurrentQueue<StreamWriter> _streammessage = new ConcurrentQueue<StreamWriter>();

        [HttpPost]
        public void Post([FromBody]XElement xml)
        {
            var reader = new StringReader(xml.ToString());
            var xmlSerializer = new XmlSerializer(typeof(InboundMessage));
            var inboundMessage = (InboundMessage)xmlSerializer.Deserialize(reader);
            MessageCallback(inboundMessage);
        }

        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            var response = request.CreateResponse();
            response.Headers.Add("Cache-Control", "no-cache");
            response.Content = new PushStreamContent((Action<Stream, HttpContent, TransportContext>)OnStreamAvailable, "text/event-stream");
            return response;
        }

        private static void OnStreamAvailable(Stream stream, HttpContent headers, TransportContext context)
        {
            var streamwriter = new StreamWriter(stream);
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