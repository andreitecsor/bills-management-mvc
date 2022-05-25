using EnterpriseBillsManagement.Data;
using EnterpriseBillsManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseBillsManagement.Controllers
{
	[Authorize]
	public class AdminController : Controller
    {
		private IBillRepository repository;
		public AdminController(IBillRepository repository)
		{
			this.repository = repository;
		}
		public IActionResult Index()
		{
			return View(repository.Bills);
		}

		public IActionResult Edit(int id)
		{
			var bill = repository.Bills.FirstOrDefault(p => p.Id == id);
			return View(bill);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Bill bill)
		{
			if (ModelState.IsValid)
			{
				await repository.SaveBillAsync(bill);
				TempData["message"] = $"Bill {bill.Id} ({bill.Type} - {bill.Provider}) has been saved";
				return RedirectToAction("Index");
			}
			else
			{
				// there is something wrong with the data values 
				return View(bill);
			}
		}

		public IActionResult Create()
		{
			return View("Edit", new Bill());
		}

	
		[HttpPost]
		[Authorize(Roles = "BillsManagement")]
		public async Task<IActionResult> Delete(int productId)
		{
			Bill deletedBill = await repository.DeleteBillAsync(productId);
			if (deletedBill != null)
			{
				TempData["message"] = $"Bill {deletedBill.Id} ({deletedBill.Type} - {deletedBill.Provider}) was deleted";
			}
			return RedirectToAction("Index");
		}
	}
}
