using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GYM.Data;
using GYM.Models;
using Microsoft.Extensions.Configuration;
using GYM.Data.GeneralSystem.IGeneralSystem;
using GYM.Utility;
using GYM.Models.ViewModels;
using GYM.Data.Builder;

namespace GYM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InvoicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISystemFacade _systemFacade;

        public InvoicesController(IConfiguration configuration, ISystemFacade systemFacade, ApplicationDbContext context)
        {
            _context = ApplicationDbContext.getInstance(configuration);
            _context = context;
            _systemFacade = systemFacade;
        }

        // GET: Admin/Invoices
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Invoices.Include(i => i.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .Include(i => i.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);

            //var invoice = _systemFacade.Operation(TableNames.Invoices_Table, id.ToString(), "read", null);

            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }


        // GET: Admin/Invoices/Details/5
        public async Task<IActionResult> GeneralDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var invoice = await _context.Invoices
                .Include(i => i.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);

            Director director = new Director();
            ProductsInvoiceDescription productsBuilder = new ProductsInvoiceDescription();

            var productBoughtsList = _context.ProductBoughts.ToList().Where(pb => pb.InvoiceId == invoice.Id);

            foreach (var productBought in productBoughtsList) {
                productBought.Invoice = invoice;
                productBought.Product = _context.Products.FirstOrDefault(p => p.Id == productBought.ProductId);
            }


            director.contructProductsInvoice(productsBuilder, productBoughtsList.ToList());
            ProductsInvoice productsInvoice = productsBuilder.productsInvoice;
            //InvoiceVM generalInvoice = new InvoiceVM()
            //{

            //    Invoice = invoice,


            //    ProductBoughtsList = _context.ProductBoughts.ToList().Where(pb => pb.InvoiceId == invoice.Id).Select(i => new SelectListItem
            //    {
            //        Text = i.Product.Name,
            //        Value = i.Id.ToString()
            //    }),

                

            //    InvoiceDescription 


            //};

            //var invoice = _systemFacade.Operation(TableNames.Invoices_Table, id.ToString(), "read", null);

            if (invoice == null)
            {
                return NotFound();
            }

            return View(productsInvoice);
        }

        // GET: Admin/Invoices/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.ApplicationUsers, "Id", "Name");
            return View();
        }

        // POST: Admin/Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PaymentDate,CustomerId")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(invoice);
                await _systemFacade.Operation(TableNames.Invoices_Table, invoice.Id.ToString(), "insert", invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", invoice.CustomerId);
            return View(invoice);
        }

        // GET: Admin/Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices.FindAsync(id);
            //var invoice = _systemFacade.Operation("invoices", id.ToString(), "read", null);
            if (invoice == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.ApplicationUsers, "Id", "Name", invoice.CustomerId);
            return View(invoice);
        }



        // POST: Admin/Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PaymentDate,CustomerId")] Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(invoice);
                    await _systemFacade.Operation(TableNames.Invoices_Table, invoice.Id.ToString(), "update", invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", invoice.CustomerId);
            return View(invoice);
        }

        

        // GET: Admin/Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .Include(i => i.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Admin/Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            //_context.Invoices.Remove(invoice);
            await _systemFacade.Operation(TableNames.Invoices_Table, invoice.Id.ToString(), "delete", invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.Id == id);
        }
    }
}
