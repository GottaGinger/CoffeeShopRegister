using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoffeeShopRegister.Models;

namespace CoffeeShopRegister.Controllers
{
    public class ProductController : Controller
    {
        private readonly CoffeeDbContext _context;

        public ProductController(CoffeeDbContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
              return _context.Coffees != null ? 
                          View(await _context.Coffees.ToListAsync()) :
                          Problem("Entity set 'CoffeeDbContext.Coffees'  is null.");
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Coffees == null)
            {
                return NotFound();
            }

            var coffee = await _context.Coffees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coffee == null)
            {
                return NotFound();
            }

            return View(coffee);
        }

        // GET: Product/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,Category")] Coffee coffee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coffee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coffee);
        }

        // GET: Product/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Coffees == null)
            {
                return NotFound();
            }

            var coffee = await _context.Coffees.FindAsync(id);
            if (coffee == null)
            {
                return NotFound();
            }
            return View(coffee);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Category")] Coffee coffee)
        {
            if (id != coffee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coffee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoffeeExists(coffee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(coffee);
        }

        // GET: Product/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Coffees == null)
            {
                return NotFound();
            }

            var coffee = await _context.Coffees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coffee == null)
            {
                return NotFound();
            }

            return View(coffee);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Coffees == null)
            {
                return Problem("Entity set 'CoffeeDbContext.Coffees'  is null.");
            }
            var coffee = await _context.Coffees.FindAsync(id);
            if (coffee != null)
            {
                _context.Coffees.Remove(coffee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoffeeExists(int id)
        {
          return (_context.Coffees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
