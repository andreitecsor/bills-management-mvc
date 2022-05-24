using EnterpriseBillsManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseBillsManagement.Data
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            Company smallCompany = new Company
            {
                Name = "SmallCompany",
                Email = "small_company@accountancy.ro",
                Address = "Flat 141, Small Building, no. 33",
                noEmployeesOnSite = 7
            };

            Company bigCompany = new Company
            {
                Name = "BigCompany",
                Email = "big_company@accountancy.com",
                Address = "Cool-Big-Shaped Building, no. 2",
                noEmployeesOnSite = 121
            };


            if (!context.Companies.Any())
            {
                context.Companies.AddRange(
                    smallCompany,
                    bigCompany
                );

                context.SaveChanges();
            }

            if (!context.Bills.Any())
            {
                context.Bills.AddRange(
                new Bill
                {
                    Provider = "Enel",
                    Type = BillType.Electricity,
                    Price = 530,
                    DueDate = new DateTime(2022, 06, 29),
                    Client = smallCompany,
                },
                new Bill
                {
                    Provider = "ApaNova",
                    Type = BillType.Water,
                    Price = 45.32m,
                    DueDate = new DateTime(2022, 06, 28),
                    Client = smallCompany,
                },
                new Bill
                {
                    Provider = "Digi",
                    Type = BillType.Electricity,
                    Price = 4555.32m,
                    DueDate = new DateTime(2022, 06, 27),
                    Client = bigCompany,
                },
                new Bill
                {
                    Provider = "Engie",
                    Type = BillType.Gas,
                    Price = 7035.22m,
                    DueDate = new DateTime(2022, 06, 01),
                    Client = bigCompany,
                }
                );

                context.SaveChanges();
            }
        }
    }
}
