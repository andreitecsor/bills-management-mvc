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

        public async Task SaveBillAsync(Bill bill)
        {
            if (bill.Id == 0)
            {
                context.Bills.Add(bill);
            }
            else
            {
                Bill dbEntry = context.Bills.FirstOrDefault(p => p.Id == bill.Id);
                if (dbEntry != null)
                {
                    dbEntry.Provider = bill.Provider;
                    dbEntry.Type = bill.Type;
                    dbEntry.Price = bill.Price;
                    dbEntry.DueDate = bill.DueDate;
                    dbEntry.Client = bill.Client;
                }
            }
            await context.SaveChangesAsync();
        }

        public async Task<Bill> DeleteBillAsync(int Id)
        {
            Bill dbEntry = context.Bills.FirstOrDefault(p => p.Id == Id);

            if (dbEntry != null)
            {
                context.Bills.Remove(dbEntry);
                await context.SaveChangesAsync();
            }

            return dbEntry;
        }
    }
}
