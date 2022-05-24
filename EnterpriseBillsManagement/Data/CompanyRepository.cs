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
    }
}
