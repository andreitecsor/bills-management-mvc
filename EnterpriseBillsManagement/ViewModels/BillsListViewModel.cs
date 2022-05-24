using EnterpriseBillsManagement.Models;
using MVCStore.ViewModels;

namespace EnterpriseBillsManagement.ViewModels
{
    public class BillsListViewModel
    {
        public IEnumerable<Bill> Bills { get; set; } = Enumerable.Empty<Bill>();
        public PagingInfoViewModel PagingInfo { get; set; } = new();
    }
}
