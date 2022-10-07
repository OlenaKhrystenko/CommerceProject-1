using CommerceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CommerceProject.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Login> Logins { get; set; }    
    }
}
