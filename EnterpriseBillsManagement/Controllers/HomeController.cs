using Microsoft.AspNetCore.Mvc;

namespace EnterpriseBillsManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
