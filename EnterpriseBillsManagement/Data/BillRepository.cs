using EnterpriseBillsManagement.Models;

namespace EnterpriseBillsManagement.Data
{
    public class BillRepository : IBillRepository
    {
        private ApplicationDbContext context;

        public BillRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Bill> Bills
        {
            get
            {
                return context.Bills;
            }
        }
    }
}
