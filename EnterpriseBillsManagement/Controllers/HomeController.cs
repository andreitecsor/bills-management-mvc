using EnterpriseBillsManagement.Data;
using EnterpriseBillsManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MVCStore.ViewModels;

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
        public ViewResult Index(int productPage = 1)
        {
            ViewBag.Title = "MVCStore";

            var bills = repository.Bills.OrderBy(x => x.Id).Skip((productPage - 1) * PageSize).Take(PageSize);

            var paggingInfo = new PagingInfoViewModel
            {
                CurrentPage = productPage,
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
