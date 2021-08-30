using System.Threading;
using System.Threading.Tasks;
using EmployeeProject.Models;
using EmployeeProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProject.Controllers
{
	[Route("edit")]
	public sealed class EditController : Controller
	{
		private readonly EmployeeContext _context;

		public EditController(EmployeeContext context)
		{
			_context = context;
		}

		[HttpGet("{workerId:required:int}")]
		public async Task<ActionResult> EditOne(int workerId)
		{
			var worker = await _context.Workers.AsNoTracking().FirstOrDefaultAsync(w => w.Id == workerId) ??
						 new Worker
						 {
							 Initials = "",
							 Position = "",
							 LastName = ""
						 };
			return View(worker);
		}

		[HttpPost]
		public async Task<ActionResult> Edit([FromForm] Worker worker, CancellationToken cancellationToken)
		{
			_context.Workers.Update(worker);
			await _context.SaveChangesAsync(cancellationToken);

			return RedirectToAction("GetAll", "Display");
		}
	}
}