using EnterpriseBillsManagement.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseBillsManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ApplicationDbContext>(opts =>
            {
                opts.UseSqlServer(
                builder.Configuration["ConnectionStrings:DefaultConnection"]);
            });

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                // change the minimum length of the password;
                options.Password.RequiredLength = 10;
                //lock the user out for 30 minutes after 5 unsuccessful attempts;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            })
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

            //-send HTTP Strict Transport Security Protocol(HSTS) headers to clients;
            app.UseHsts(); //Not recommended for dev env because the HSTS settings are highly cacheable by browsers
            
            //redirect HTTP requests to HTTPS;
            app.UseHttpsRedirection();

            SeedData.EnsurePopulated(app);
            Task.Run(async () =>
            {
                await SeedDataIdentity.EnsurePopulatedAsync(app);
            }).Wait();

            app.Run();
           
        }
    }
}