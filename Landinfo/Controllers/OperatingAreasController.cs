using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Landinfo.DAL.Data;
using Landinfo.DAL.Data.Model;

namespace Landinfo.Controllers
{
    public class OperatingAreasController : Controller
    {
        private readonly LandinfoDbContext _context;

        public OperatingAreasController(LandinfoDbContext context)
        {
            _context = context;
        }

        // GET: OperatingAreas
        public async Task<IActionResult> Index()
        {
            return View(await _context.OperatingAreas.ToListAsync());
        }

        // GET: OperatingAreas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operatingArea = await _context.OperatingAreas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (operatingArea == null)
            {
                return NotFound();
            }

            return View(operatingArea);
        }

        // GET: OperatingAreas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OperatingAreas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AreaName")] OperatingArea operatingArea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operatingArea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(operatingArea);
        }

        // GET: OperatingAreas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operatingArea = await _context.OperatingAreas.FindAsync(id);
            if (operatingArea == null)
            {
                return NotFound();
            }
            return View(operatingArea);
        }

        // POST: OperatingAreas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AreaName")] OperatingArea operatingArea)
        {
            if (id != operatingArea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operatingArea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperatingAreaExists(operatingArea.Id))
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
            return View(operatingArea);
        }

        // GET: OperatingAreas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operatingArea = await _context.OperatingAreas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (operatingArea == null)
            {
                return NotFound();
            }

            return View(operatingArea);
        }

        // POST: OperatingAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var operatingArea = await _context.OperatingAreas.FindAsync(id);
            _context.OperatingAreas.Remove(operatingArea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperatingAreaExists(int id)
        {
            return _context.OperatingAreas.Any(e => e.Id == id);
        }
    }
}
