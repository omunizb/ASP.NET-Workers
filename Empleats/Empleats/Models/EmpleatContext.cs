using Microsoft.EntityFrameworkCore;

namespace Empleats.Models
{
    public class EmpleatContext : DbContext
    {
        public EmpleatContext(DbContextOptions<EmpleatContext> options)
            : base(options)
        {
        }

        public DbSet<EmpleatItem> EmpleatItems { get; set; }
    }
}
