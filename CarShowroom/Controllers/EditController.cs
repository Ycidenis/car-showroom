using System;
using System.Threading.Tasks;
using CarShowroom.Models;
using CarShowroom.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarShowroom.Controllers
{
    [Route("edit")]
    public sealed class EditController : Controller
    {
        private readonly CarShowroomContext _context;

        public EditController(CarShowroomContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromForm] Car car)
        {
            _context.Update(car);
            await _context.SaveChangesAsync();

            return RedirectToAction("ViewAll", "Display");
        }

        [HttpGet]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult> EditOne(Guid id)
        {
            var car = await _context.Cars.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id.ToString()) ?? new Car
            {
                Color = "",
                Manufacturer = "",
                Model = "",
                AmountLeft = 0,
                EnginePower = "",
                EngineType = "",
                ImageUrl = "",
                AmountOfCylinders = 0,
                DateOfCreation = DateTime.Now
            };

            return View(car);
        }
    }
}