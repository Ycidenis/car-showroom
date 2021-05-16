using System.Threading.Tasks;
using CarShowroom.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarShowroom.Controllers
{
    [Route("")]
    public sealed class DisplayController : Controller
    {
        private readonly CarShowroomContext _context;

        public DisplayController(CarShowroomContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> ViewAll()
        {
            var allCars = await _context.Cars.AsNoTracking().ToListAsync();
            return View(allCars);
        }
    }
}