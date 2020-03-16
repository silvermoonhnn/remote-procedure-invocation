using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace notification_services.Domain.Entities
{
    public class LogsEn
    {
        public int Id { get; set; }
        public int Notification_Id { get; set; }
        public string Type { get; set; }
        public int From { get; set; }
        public List<Target> Target { get; set; }
        public string Email_Destination { get; set; }
        public DateTime ReadAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [JsonIgnore]
        public NotifEn notif { get; set; }
    }

    public class Target
    {
        public int Id { get; set; }
        public string Email_Destination { get; set; }
    }
}