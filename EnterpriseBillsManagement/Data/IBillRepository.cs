using EnterpriseBillsManagement.Models;

namespace EnterpriseBillsManagement.Data
{
    public interface IBillRepository
    {
        IQueryable<Bill> Bills { get; }

        Task SaveBillAsync(Bill bill);

        Task<Bill> DeleteBillAsync(int Id);
    }
}
