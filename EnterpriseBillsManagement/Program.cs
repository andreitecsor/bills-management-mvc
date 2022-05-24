using EnterpriseBillsManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseBillsManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(opts => {
                opts.UseSqlServer(
                builder.Configuration["ConnectionStrings:DefaultConnection"]);
            });

            builder.Services.AddScoped<IBillRepository, BillRepository>();
            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

            var app = builder.Build();
            app.UseStaticFiles();
            app.MapDefaultControllerRoute();
            SeedData.EnsurePopulated(app);
            app.Run();
        }
    }
}