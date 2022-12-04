using CommerceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CommerceProject.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        //public DbSet<Login> Logins { get; set; }    
        //public DbSet<Donor> Donors { get; set; }
        public DbSet<DonationForm> donationForms { get; set; }
        //public DbSet<Fundraiser> Fundraisers { get; set; }

        public DbSet<Fundraisers> Fundraisers { get; set; }
        //public DbSet<UserProfile> Profiles { get; set; }
        //public DbSet<Image> Images { get; set; }
    }
}
