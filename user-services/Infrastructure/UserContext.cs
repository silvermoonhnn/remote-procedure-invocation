using Microsoft.EntityFrameworkCore;
using user_services.Domain.Entities;

namespace user_services.Infrastructure
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> op) : base(op) {}

        public DbSet<UserEn> Users { get; set; }
    }
}