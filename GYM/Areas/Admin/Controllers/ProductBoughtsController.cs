using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GYM.Data;
using GYM.Models;
using GYM.Data.GeneralSystem.IGeneralSystem;
using Microsoft.Extensions.Configuration;
using GYM.Utility;

namespace GYM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductBoughtsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISystemFacade _systemFacade;

        public ProductBoughtsController(IConfiguration configuration, ISystemFacade systemFacade, ApplicationDbContext context)
        {
            _context = ApplicationDbContext.getInstance(configuration);
            _context = context;
            _systemFacade = systemFacade;
        }

        // GET: Admin/ProductBoughts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductBoughts.Include(p => p.Invoice).Include(p => p.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/ProductBoughts
        public async Task<IActionResult> Carrito()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Admin/ProductBoughts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productBought = await _context.ProductBoughts
                .Include(p => p.Invoice)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productBought == null)
            {
                return NotFound();
            }

            return View(productBought);
        }

        public async Task<IActionResult> DetallesTienda(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/ProductBoughts/Create
        public IActionResult Create()
        {
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            return View();
        }

        // POST: Admin/ProductBoughts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InvoiceId,ProductId,Quantity")] ProductBought productBought)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(productBought);
                await _systemFacade.Operation(TableNames.ProductBoughts_Table, productBought.Id.ToString(), "insert", productBought);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id", productBought.InvoiceId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", productBought.ProductId);
            return View(productBought);
        }

        // GET: Admin/ProductBoughts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productBought = await _context.ProductBoughts.FindAsync(id);
            if (productBought == null)
            {
                return NotFound();
            }
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id", productBought.InvoiceId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", productBought.ProductId);
            return View(productBought);
        }

        // POST: Admin/ProductBoughts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InvoiceId,ProductId,Quantity")] ProductBought productBought)
        {
            if (id != productBought.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(productBought);
                    await _systemFacade.Operation(TableNames.ProductBoughts_Table, productBought.Id.ToString(), "update", productBought);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductBoughtExists(productBought.Id))
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
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "CustomerId", productBought.InvoiceId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Description", productBought.ProductId);
            return View(productBought);
        }

        // GET: Admin/ProductBoughts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productBought = await _context.ProductBoughts
                .Include(p => p.Invoice)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productBought == null)
            {
                return NotFound();
            }

            return View(productBought);
        }

        // POST: Admin/ProductBoughts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productBought = await _context.ProductBoughts.FindAsync(id);
            //_context.ProductBoughts.Remove(productBought);
            await _systemFacade.Operation(TableNames.ProductBoughts_Table, productBought.Id.ToString(), "delete", productBought);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductBoughtExists(int id)
        {
            return _context.ProductBoughts.Any(e => e.Id == id);
        }
    }
}
