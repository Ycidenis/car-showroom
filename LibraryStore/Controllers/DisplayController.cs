using System.Threading.Tasks;
using LibraryStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryStore.Controllers
{
    [Route("")]
    public sealed class DisplayController : Controller
    {
        private readonly LibraryStoreContext _context;

        public DisplayController(LibraryStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> ViewAll()
        {
            var allBooks = await _context.Books.AsNoTracking().ToListAsync();
            return View(allBooks);
        }
    }
}