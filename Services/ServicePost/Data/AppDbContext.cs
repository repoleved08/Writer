using Microsoft.EntityFrameworkCore;
using ServicePost.Model;

namespace ServicePost.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
    }
}
