using Microsoft.AspNetCore.Identity;

namespace EnterpriseBillsManagement.Data
{
    public class SeedDataIdentity
    {
        public static async Task EnsurePopulatedAsync(IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices
            .CreateScope().ServiceProvider;

            using (var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>())
            {

                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // Bills Management Role
                var managerRoleName = "BillsManagement";

                if (!await roleManager.RoleExistsAsync(managerRoleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(managerRoleName));
                }

                var managerEmail = "administrator@bills.ent";
                var managerPassword = "Secret123$";

                IdentityUser manager = await userManager.FindByEmailAsync(managerEmail);
                if (manager == null)
                {
                    manager = new IdentityUser { UserName = managerEmail, Email = managerEmail };
                    await userManager.CreateAsync(manager, managerPassword);
                    await userManager.AddToRoleAsync(manager, managerRoleName);
                }

                // Bills Worker Role
                var workerRoleName = "BillsWorker";

                if (!await roleManager.RoleExistsAsync(workerRoleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(workerRoleName));
                }

                var workerEmail = "worker@bills.ent";
                var workerPassword = "123!Secret";

                IdentityUser worker = await userManager.FindByEmailAsync(workerEmail);
                if (worker == null)
                {
                    worker = new IdentityUser { UserName = workerEmail, Email = workerEmail };
                    await userManager.CreateAsync(worker, workerPassword);
                    await userManager.AddToRoleAsync(worker, workerRoleName);
                }

                // Bills Audit Role
                var auditRoleName = "AuditBills";

                if (!await roleManager.RoleExistsAsync(auditRoleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(auditRoleName));
                }

                var auditorEmail = "audit@bills.ent";
                var auditorPassword = "345Secret@";

                IdentityUser auditor = await userManager.FindByEmailAsync(auditorEmail);
                if (auditor == null)
                {
                    auditor = new IdentityUser { UserName = auditorEmail, Email = auditorEmail };
                    await userManager.CreateAsync(auditor, auditorPassword);
                    await userManager.AddToRoleAsync(auditor, auditRoleName);
                }
            }
        }
    }
}
