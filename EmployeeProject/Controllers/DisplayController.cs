using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmployeeProject.Models;
using EmployeeProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProject.Controllers
{
	[Route("")]
	public sealed class DisplayController : Controller
	{
		private readonly EmployeeContext _context;

		public DisplayController(EmployeeContext context)
		{
			_context = context;
		}
		
		[HttpGet("{yearsOfExperience:int}")]
		public async Task<ActionResult> GetAll([FromQuery] int? yearsOfExperience, CancellationToken cancellationToken)
		{
			IQueryable<Worker> query = _context.Workers.AsNoTracking();
			if (yearsOfExperience != null)
			{
				int expectedYearOfWorkBeginning = DateTime.Now.Year - yearsOfExperience.Value;
				query = query.Where(it => it.YearOfWorkBeginning < expectedYearOfWorkBeginning);
			}

			var workers = await query.ToListAsync(cancellationToken);
			return View(workers);
		}
	}
}