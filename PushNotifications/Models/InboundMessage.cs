﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PushNotifications.Models
{
    public class InboundMessage
    {
        public Guid Id { get; set; }
        public Guid MessageId { get; set; }
        public Guid AccountId { get; set; }
        public string MessageText { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Now { get; set; }
    }
}