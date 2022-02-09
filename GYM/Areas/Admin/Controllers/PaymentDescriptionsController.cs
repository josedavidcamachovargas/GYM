using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GYM.Data;
using GYM.Models;
using Microsoft.AspNetCore.Authorization;
using GYM.Utility;
using GYM.Data.GeneralSystem.IGeneralSystem;
using Microsoft.Extensions.Configuration;

namespace GYM.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RoleNames.Role_Admin)]
    public class PaymentDescriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISystemFacade _systemFacade;

        public PaymentDescriptionsController(IConfiguration configuration, ISystemFacade systemFacade, ApplicationDbContext context)
        {
            _context = ApplicationDbContext.getInstance(configuration);
            _context = context;
            _systemFacade = systemFacade;
        }

        // GET: Admin/PaymentDescriptions
        public async Task<IActionResult> Index()
        {
            return View(await _context.PaymentDescriptions.ToListAsync());
        }

        // GET: Admin/PaymentDescriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentDescription = await _context.PaymentDescriptions
                .FirstOrDefaultAsync(m => m.Id == id);

            //var paymentDescription = _systemFacade.Operation(TableNames.PaymentDescriptions_Table, id.ToString(), "read", null);

            if (paymentDescription == null)
            {
                return NotFound();
            }

            return View(paymentDescription);
        }

        // GET: Admin/PaymentDescriptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/PaymentDescriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Models.PaymentDescription paymentDescription)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(paymentDescription);
                await _systemFacade.Operation(TableNames.PaymentDescriptions_Table, paymentDescription.Id.ToString(), "insert", paymentDescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentDescription);
        }

        // GET: Admin/PaymentDescriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentDescription = await _context.PaymentDescriptions.FindAsync(id);
            if (paymentDescription == null)
            {
                return NotFound();
            }
            return View(paymentDescription);
        }

        // POST: Admin/PaymentDescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Models.PaymentDescription paymentDescription)
        {
            if (id != paymentDescription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(paymentDescription);
                    await _systemFacade.Operation(TableNames.PaymentDescriptions_Table, paymentDescription.Id.ToString(), "update", paymentDescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentDescriptionExists(paymentDescription.Id))
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
            return View(paymentDescription);
        }

        // GET: Admin/PaymentDescriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentDescription = await _context.PaymentDescriptions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentDescription == null)
            {
                return NotFound();
            }

            return View(paymentDescription);
        }

        // POST: Admin/PaymentDescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentDescription = await _context.PaymentDescriptions.FindAsync(id);
            //_context.PaymentDescriptions.Remove(paymentDescription);
            await _systemFacade.Operation(TableNames.PaymentDescriptions_Table, paymentDescription.Id.ToString(), "delete", paymentDescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentDescriptionExists(int id)
        {
            return _context.PaymentDescriptions.Any(e => e.Id == id);
        }
    }
}
