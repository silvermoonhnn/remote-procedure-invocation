using System.Collections.Generic;

namespace user_services.Application.UseCases.Users.Model
{
    public class UserNo
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public int From { get; set; }
        public List<Target> Targets { get; set; }
    }
    
    public class Target
    {
        public int Id { get; set; }
        public string EmailDestination { get; set; }
    }
}