using EnterpriseBillsManagement.Models;

namespace EnterpriseBillsManagement.ViewModels
{
    public class CompanyListViewModel
    {
        public IEnumerable<Company> Bills { get; set; } = Enumerable.Empty<Company>();
        public PagingInfoViewModel PagingInfo { get; set; } = new();
    }
}
