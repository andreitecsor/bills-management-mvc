using EnterpriseBillsManagement.Data;
using EnterpriseBillsManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseBillsManagement.Controllers
{
    [Authorize]
    public class BillController : Controller
    {
        private IBillRepository repository;

        private static int selectedCompanyId;

        public BillController(IBillRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index(int companyId)
        {
            if (companyId != 0)
            {
                selectedCompanyId = companyId;
            }
            var billsOfSelectedCompany = repository.Bills.Where(b => b.CompanyId == companyId);
            return View(billsOfSelectedCompany);
        }

        public IActionResult Edit(int id)
        {
            ViewData["SelectedCompany"] = selectedCompanyId;
            var bill = repository.Bills.FirstOrDefault(p => p.Id == id);
            return View(bill);
        }

        public IActionResult ReturnToCompanies()
        {
            return RedirectToAction("Index", "Company");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Bill bill)
        {
            bill.DueDate = DateTime.Today;
            bill.CompanyId = selectedCompanyId;
            if (ModelState.IsValid)
            {
                await repository.SaveBillAsync(bill);
                TempData["message"] = $"Bill {bill.Id} ({bill.Type} - {bill.Provider}) has been saved";
                return RedirectToAction("Index", new { @companyId = selectedCompanyId });
            }
            else
            {
                TempData["message"] = $"Invalid Bill";
                return View(bill);
            }
        }

        public IActionResult Create()
        {
            ViewData["SelectedCompany"] = selectedCompanyId;
            return View("Edit", new Bill());
        }


        [HttpPost]
        [Authorize(Roles = "BillsManagement")]
        public async Task<IActionResult> Delete(int billId)
        {
            Bill deletedBill = await repository.DeleteBillAsync(billId);
            if (deletedBill != null)
            {
                TempData["message"] = $"Bill {deletedBill.Id} ({deletedBill.Type} - {deletedBill.Provider}) was deleted";
            }
            return RedirectToAction("Index", new { @companyId = selectedCompanyId }); ;
        }
    }
}
