using EnterpriseBillsManagement.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseBillsManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ApplicationDbContext>(opts => {
                opts.UseSqlServer(
                builder.Configuration["ConnectionStrings:DefaultConnection"]);
            });

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddRoleManager<RoleManager<IdentityRole>>()
        .AddDefaultUI()
        .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IBillRepository, BillRepository>();
            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

            var app = builder.Build();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute("pagination",
                "Bills/Page{billPage}",
                new { Controller = "Home", action = "Index" });
            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            SeedData.EnsurePopulated(app);
            Task.Run(async () =>
            {
                await SeedDataIdentity.EnsurePopulatedAsync(app);
            }).Wait();

            app.Run();
            

    
        }
    }
}