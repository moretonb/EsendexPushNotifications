using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(PushNotifications.Startup))]
namespace PushNotifications
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}