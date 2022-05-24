using EnterpriseBillsManagement.Data;
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
        public IActionResult Index(int billPage = 1)
        {
            var bills = repository.Bills
            .OrderBy(p => p.Id)
            .Skip((billPage - 1) * PageSize)
            .Take(PageSize);

            return View(bills);
        }
    }
}
