using EnterpriseBillsManagement.Data;
using EnterpriseBillsManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseBillsManagement.Controllers
{
    public class HomeController : Controller
    {

        public ViewResult Index()
        {
            return View();
        }
    }
}
