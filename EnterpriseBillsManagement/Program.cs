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

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(opts =>
            {
                opts.UseSqlServer(
                builder.Configuration["ConnectionStrings:DefaultConnection"]);
            });

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
          .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddScoped<IBillRepository, BillRepository>();
            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

            var app = builder.Build();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapRazorPages();
            app.MapControllerRoute("pagination", "Bills/Page{productPage}", new { Controller = "Home", action = "Index" });
            app.MapDefaultControllerRoute();
            SeedData.EnsurePopulated(app);
            Task.Run(async () =>
            {
                await SeedDataIdentity.EnsurePopulatedAsync(app);
            }).Wait();
            app.Run();
        }
    }
}