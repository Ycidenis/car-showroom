using System;
using System.Threading.Tasks;
using LibraryStore.Models;
using LibraryStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryStore.Controllers
{
    [Route("edit")]
    public sealed class EditController : Controller
    {
        private readonly LibraryStoreContext _context;

        public EditController(LibraryStoreContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromForm] Book book)
        {
            _context.Update(book);
            await _context.SaveChangesAsync();

            return RedirectToAction("ViewAll", "Display");
        }

        [HttpGet]
        [HttpGet("{id:required:int}")]
        public async Task<ActionResult> EditOne(int id)
        {
            var car = await _context.Books.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id) ?? new Book
            {
                StorageCode = "",
                PublishCode = "",
                AuthorCode = "",
                PublishYear = DateTime.Now.Year,
                Name = "",
                ImageUrl = "",
                ShortDescription = ""
            };

            return View(car);
        }
    }
}