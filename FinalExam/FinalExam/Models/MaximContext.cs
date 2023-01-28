using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Models
{
    public class MaximContext:IdentityDbContext
    {
        public MaximContext(DbContextOptions<MaximContext> options):base(options) { }
        
        public DbSet<AppUser> Users { get; set; }

        public DbSet<ServicesSection> servicesSections { get; set; }
    }
}
