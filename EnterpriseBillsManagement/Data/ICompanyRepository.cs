using EnterpriseBillsManagement.Models;

namespace EnterpriseBillsManagement.Data
{
    public interface ICompanyRepository
    {
        IQueryable<Company> Companies { get; }
    }
}
