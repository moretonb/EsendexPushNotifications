namespace PushNotifications.Models
{
    public class AccountEventHandlerOptions
    {
        public string username { get; set; }
        public string password { get; set; }
        public string account { get; set; }
        public string notificationType { get; set; }
        public string id { get; set; }
        public string originator { get; set; }
        public string recipient { get; set; }
        public string body { get; set; }
        public string type { get; set; }
        public string sentAt { get; set; }
        public string receivedAt { get; set; }
    }
}
