using System;

namespace notification_services.Domain.Entities
{
    public class NotifEn
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }  
    }
}