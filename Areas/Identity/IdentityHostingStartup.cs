
using CommerceProject.Areas.Identity.Data;
using CommerceProject.Data;
using Microsoft.EntityFrameworkCore;

[assembly: HostingStartup(typeof(CommerceProject.Areas.Identity.IdentityHostingStartup))]
namespace CommerceProject.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {

            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CommerceProjectContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CommerceProjectContextConnection")));

                services.AddDefaultIdentity<CommerceProjectUser>(options => {

                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                    .AddEntityFrameworkStores<CommerceProjectContext>();
            });
        }
    }
}
