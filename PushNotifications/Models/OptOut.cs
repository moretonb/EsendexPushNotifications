using System;

namespace PushNotifications.Models
{
    public class OptOut
    {
        public Guid Id { get; set; }
        public string AccountReference { get; set; }
        public Guid AccountId { get; set; }
        public DateTime ReceviedAt { get; set; }
        public From From { get; set; }
    }

    public class From
    {
        public string PhoneNumber { get; set; }
    }
}