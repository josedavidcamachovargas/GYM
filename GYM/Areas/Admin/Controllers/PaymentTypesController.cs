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
    public class PaymentTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISystemFacade _systemFacade;

        public PaymentTypesController(IConfiguration configuration, ISystemFacade systemFacade, ApplicationDbContext context)
        {
            _context = ApplicationDbContext.getInstance(configuration);
            _context = context;
            _systemFacade = systemFacade;
        }

        // GET: Admin/PaymentTypes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PaymentTypes.Include(p => p.Customer).Include(p => p.Description);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/PaymentTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentType = await _context.PaymentTypes
                .Include(p => p.Customer)
                .Include(p => p.Description)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentType == null)
            {
                return NotFound();
            }

            return View(paymentType);
        }

        // GET: Admin/PaymentTypes/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.ApplicationUsers, "Id", "Name");
            ViewData["DescriptionId"] = new SelectList(_context.PaymentDescriptions, "Id", "Name");
            return View();
        }

        // POST: Admin/PaymentTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PaymentDate,DescriptionId,Payment,PeriodOfTime,PaymentMean,CustomerId,ExpirationDate")] PaymentType paymentType)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(paymentType);
                await _systemFacade.Operation(TableNames.PaymentTypes_Table, paymentType.Id.ToString(), "insert", paymentType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", paymentType.CustomerId);
            ViewData["DescriptionId"] = new SelectList(_context.PaymentDescriptions, "Id", "Name", paymentType.DescriptionId);
            return View(paymentType);
        }

        // GET: Admin/PaymentTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentType = await _context.PaymentTypes.FindAsync(id);
            if (paymentType == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.ApplicationUsers, "Id", "Name", paymentType.CustomerId);
            ViewData["DescriptionId"] = new SelectList(_context.PaymentDescriptions, "Id", "Name", paymentType.DescriptionId);
            return View(paymentType);
        }

        // POST: Admin/PaymentTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PaymentDate,DescriptionId,Payment,PeriodOfTime,PaymentMean,CustomerId,ExpirationDate")] PaymentType paymentType)
        {
            if (id != paymentType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(paymentType);
                    await _systemFacade.Operation(TableNames.PaymentTypes_Table, paymentType.Id.ToString(), "update", paymentType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentTypeExists(paymentType.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", paymentType.CustomerId);
            ViewData["DescriptionId"] = new SelectList(_context.PaymentDescriptions, "Id", "Name", paymentType.DescriptionId);
            return View(paymentType);
        }

        // GET: Admin/PaymentTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentType = await _context.PaymentTypes
                .Include(p => p.Customer)
                .Include(p => p.Description)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentType == null)
            {
                return NotFound();
            }

            return View(paymentType);
        }

        // POST: Admin/PaymentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentType = await _context.PaymentTypes.FindAsync(id);
            //_context.PaymentTypes.Remove(paymentType);
            await _systemFacade.Operation(TableNames.PaymentTypes_Table, paymentType.Id.ToString(), "delete", paymentType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentTypeExists(int id)
        {
            return _context.PaymentTypes.Any(e => e.Id == id);
        }
    }
}
