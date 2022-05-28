using EnterpriseBillsManagement.Data;
using EnterpriseBillsManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseBillsManagement.Controllers
{
    public class CompanyController : Controller
    {
        private ICompanyRepository repository;

        public CompanyController(ICompanyRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(repository.Companies);
        }

		public IActionResult Edit(int id)
		{
			var company = repository.Companies.FirstOrDefault(p => p.Id == id);
			return View(company);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Company company)
		{
			if (ModelState.IsValid)
			{
				await repository.SaveCompanyAsync(company);
				TempData["message"] = $"Company {company.Name} ({company.Id}) has been saved";
				return RedirectToAction("Index");
			}
			else
			{
				return View(company);
			}
		}

		public IActionResult Select(int id)
        {
			return RedirectToAction("Index","Bill", new { @companyId = id });
        }

		public IActionResult Create()
		{
			return View("Edit", new Company());
		}


		[HttpPost]
		[Authorize(Roles = "BillsManagement")]
		public async Task<IActionResult> Delete(int companyId)
		{
			Company deletedComapany = await repository.DeleteCompanyAsync(companyId);
			if (deletedComapany != null)
			{
				TempData["message"] = $"Bill {deletedComapany.Name} ({deletedComapany.Id}) was deleted";
			}
			return RedirectToAction("Index");
		}
	}
}

