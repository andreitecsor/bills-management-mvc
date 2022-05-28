using EnterpriseBillsManagement.Models;

namespace EnterpriseBillsManagement.Data
{
    public interface ICompanyRepository
    {
        IQueryable<Company> Companies { get; }

        Task SaveCompanyAsync(Company company);

        Task<Company> DeleteCompanyAsync(int Id);
    }
}
