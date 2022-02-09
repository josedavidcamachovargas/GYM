using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GYM.Data;
using GYM.Models;

namespace GYM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InvoiceDescriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvoiceDescriptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/InvoiceDescriptions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.InvoiceDescriptions.Include(i => i.Invoice);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/InvoiceDescriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceDescription = await _context.InvoiceDescriptions
                .Include(i => i.Invoice)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceDescription == null)
            {
                return NotFound();
            }

            return View(invoiceDescription);
        }

        // GET: Admin/InvoiceDescriptions/Create
        public IActionResult Create()
        {
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "CustomerId");
            return View();
        }

        // POST: Admin/InvoiceDescriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TotalDescription,InvoiceId")] InvoiceDescription invoiceDescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoiceDescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "CustomerId", invoiceDescription.InvoiceId);
            return View(invoiceDescription);
        }

        // GET: Admin/InvoiceDescriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceDescription = await _context.InvoiceDescriptions.FindAsync(id);
            if (invoiceDescription == null)
            {
                return NotFound();
            }
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "CustomerId", invoiceDescription.InvoiceId);
            return View(invoiceDescription);
        }

        // POST: Admin/InvoiceDescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TotalDescription,InvoiceId")] InvoiceDescription invoiceDescription)
        {
            if (id != invoiceDescription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoiceDescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceDescriptionExists(invoiceDescription.Id))
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
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "CustomerId", invoiceDescription.InvoiceId);
            return View(invoiceDescription);
        }

        // GET: Admin/InvoiceDescriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceDescription = await _context.InvoiceDescriptions
                .Include(i => i.Invoice)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceDescription == null)
            {
                return NotFound();
            }

            return View(invoiceDescription);
        }

        // POST: Admin/InvoiceDescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoiceDescription = await _context.InvoiceDescriptions.FindAsync(id);
            _context.InvoiceDescriptions.Remove(invoiceDescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceDescriptionExists(int id)
        {
            return _context.InvoiceDescriptions.Any(e => e.Id == id);
        }
    }
}
