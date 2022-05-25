using EnterpriseBillsManagement.Data;
using EnterpriseBillsManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseBillsManagement.Controllers
{
    public class HomeController : Controller
    {
        private IBillRepository repository;
        public int PageSize = 2;

        public HomeController(IBillRepository repository)
        {
            this.repository = repository;
        }
        public ViewResult Index(int billPage = 1)
        {
            ViewBag.Title = "Enterprise Bills Management";

            var bills = repository.Bills.OrderBy(x => x.Id).Skip((billPage - 1) * PageSize).Take(PageSize);

            var paggingInfo = new PagingInfoViewModel
            {
                CurrentPage = billPage,
                ItemsPerPage = PageSize,
                TotalItems = repository.Bills.Count()
            };

            BillsListViewModel viewModel = new BillsListViewModel()
            {
                Bills = bills,
                PagingInfo = paggingInfo
            };

            return View(viewModel);
        }
    }
}
