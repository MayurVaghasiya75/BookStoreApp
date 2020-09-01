using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.DAL;
using BookStoreApp.Data;

namespace BookStoreApp.Controllers
{
    public class PrintersController : Controller
    {
        private readonly EFBookContext _context;

        public PrintersController(EFBookContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Printers.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.data = _context.Printers.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Brand,Model")] Printer printer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(printer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(printer);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var printer = await _context.Printers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (printer == null)
            {
                return NotFound();
            }

            return View(printer);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var printer = await _context.Printers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (printer == null)
            {
                return NotFound();
            }

            return View(printer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var printer = await _context.Printers.FindAsync(id);
            _ = _context.Printers.Remove(printer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var printer = await _context.Printers.FindAsync(id);
            if (printer == null)
            {
                return NotFound();
            }
            return View(printer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Model,Brand")] Printer printer)
        {
            if (id != printer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(printer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrinterExists(printer.ID))
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
            return View(printer);
        }
        private bool PrinterExists(int id)
        {
            return _context.Printers.Any(e => e.ID == id);
        }
    }
}
