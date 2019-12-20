using Arch_Prototype.Domain.Auth;
using Microsoft.EntityFrameworkCore;

namespace Arch_Prototype.Infra.Data.Contexts
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }
    }
}