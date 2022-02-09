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
    public class PhysicalConditionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISystemFacade _systemFacade;

        public PhysicalConditionsController(IConfiguration configuration, ISystemFacade systemFacade, ApplicationDbContext context)
        {
            _context = ApplicationDbContext.getInstance(configuration);
            _context = context;
            _systemFacade = systemFacade;
        }

        // GET: Admin/PhysicalConditions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PhysicalConditions.Include(p => p.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/PhysicalConditions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var physicalCondition = await _context.PhysicalConditions
                .Include(p => p.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (physicalCondition == null)
            {
                return NotFound();
            }

            return View(physicalCondition);
        }

        // GET: Admin/PhysicalConditions/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.ApplicationUsers, "Id", "Name");
            return View();
        }

        // POST: Admin/PhysicalConditions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Weight,Height,Diseases,Medicines,CustomerId")] PhysicalCondition physicalCondition)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(physicalCondition);
                await _systemFacade.Operation(TableNames.PhysicalConditions_Table, physicalCondition.Id.ToString(), "insert", physicalCondition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", physicalCondition.CustomerId);
            return View(physicalCondition);
        }

        // GET: Admin/PhysicalConditions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var physicalCondition = await _context.PhysicalConditions.FindAsync(id);
            if (physicalCondition == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.ApplicationUsers, "Id", "Name", physicalCondition.CustomerId);
            return View(physicalCondition);
        }

        // POST: Admin/PhysicalConditions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Weight,Height,Diseases,Medicines,CustomerId")] PhysicalCondition physicalCondition)
        {
            if (id != physicalCondition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(physicalCondition);
                    await _systemFacade.Operation(TableNames.PhysicalConditions_Table, physicalCondition.Id.ToString(), "update", physicalCondition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhysicalConditionExists(physicalCondition.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", physicalCondition.CustomerId);
            return View(physicalCondition);
        }

        // GET: Admin/PhysicalConditions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var physicalCondition = await _context.PhysicalConditions
                .Include(p => p.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (physicalCondition == null)
            {
                return NotFound();
            }

            return View(physicalCondition);
        }

        // POST: Admin/PhysicalConditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var physicalCondition = await _context.PhysicalConditions.FindAsync(id);
            //_context.PhysicalConditions.Remove(physicalCondition);
            await _systemFacade.Operation(TableNames.PhysicalConditions_Table, physicalCondition.Id.ToString(), "delete", physicalCondition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhysicalConditionExists(int id)
        {
            return _context.PhysicalConditions.Any(e => e.Id == id);
        }
    }
}
