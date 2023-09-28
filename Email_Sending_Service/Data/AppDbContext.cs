using Email_Sending_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Email_Sending_Service.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        public DbSet<EmailDto> EmailDtos { get; set; }
    }
}
