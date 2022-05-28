using EnterpriseBillsManagement.Models;

namespace EnterpriseBillsManagement.Data
{
    public class CompanyRepository : ICompanyRepository
    {
        private ApplicationDbContext context;

        public CompanyRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Company> Companies
        {
            get
            {
                return context.Companies;
            }
        }

        public async Task<Company> DeleteCompanyAsync(int Id)
        {
            Company dbEntry = context.Companies.FirstOrDefault(p => p.Id == Id);

            if (dbEntry != null)
            {
                context.Companies.Remove(dbEntry);
                await context.SaveChangesAsync();
            }

            return dbEntry;
        }

        public async Task SaveCompanyAsync(Company company)
        {
            if (company.Id == 0)
            {
                context.Companies.Add(company);
            }
            else
            {
                Company dbEntry = context.Companies.FirstOrDefault(p => p.Id == company.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = company.Name;
                    dbEntry.Email = company.Email;
                    dbEntry.Address = company.Address;
                    dbEntry.noEmployeesOnSite = company.noEmployeesOnSite;

                }
            }
            await context.SaveChangesAsync();
        }
    }


}
