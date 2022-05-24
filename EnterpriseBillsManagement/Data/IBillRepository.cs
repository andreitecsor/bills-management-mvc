using EnterpriseBillsManagement.Models;

namespace EnterpriseBillsManagement.Data
{
    public interface IBillRepository
    {
        IQueryable<Bill> Bills { get; }
    }
}
