using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Landinfo.DAL.Data;
using Landinfo.DAL.Data.Model;
using Landinfo.Services.Services;

namespace Landinfo.Controllers
{
    public class PropertyInfoesController : Controller
    {
        private readonly LandinfoDbContext _context;
        private readonly IPropertyInfoService _propertyInfoService;

        public PropertyInfoesController(LandinfoDbContext context, IPropertyInfoService propertyInfoService)
        {
            _context = context;
            _propertyInfoService = propertyInfoService;
        }

        // GET: PropertyInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _propertyInfoService.GetAllPropertyInfos());
        }

        //GET method for retriving states using country id
        public async Task<IActionResult> GetStates(int id)
        {
            var states = new List<State>();
            states = await _propertyInfoService.GetStatesByCountryId(id);
            return Json(states);
        }

        // GET: PropertyInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyInfo = await _context.PropertyInfos
                .Include(p => p.Company)
                .Include(p => p.Field)
                .Include(p => p.OperatingArea)
                .Include(p => p.Property)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propertyInfo == null)
            {
                return NotFound();
            }

            return View(propertyInfo);
        }

        // GET: PropertyInfoes/Create
        public IActionResult Create()
        {
            ViewData["UniqueId"] = (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            ViewData["CreatedOn"] = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "CompanyName");
            ViewData["FieldId"] = new SelectList(_context.Fields, "Id", "FieldName");
            ViewData["OperatingAreaId"] = new SelectList(_context.OperatingAreas, "Id", "AreaName");
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "PropertyName");
            return View();
        }

        // POST: PropertyInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UniqueId,MapId,Rural,Dls,LocationLat,LocationLong,Address,City,ZipCode,Country,State,CompanyId,OperatingAreaId,FieldId,PropertyId,IsActive,CreatedOn,UpdatedOn")] PropertyInfo propertyInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propertyInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "CompanyName", propertyInfo.CompanyId);
            ViewData["FieldId"] = new SelectList(_context.Fields, "Id", "FieldName", propertyInfo.FieldId);
            ViewData["OperatingAreaId"] = new SelectList(_context.OperatingAreas, "Id", "AreaName", propertyInfo.OperatingAreaId);
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "PropertyName", propertyInfo.PropertyId);
            return View(propertyInfo);
        }

        // GET: PropertyInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyInfo = await _context.PropertyInfos.FindAsync(id);
            if (propertyInfo == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "CompanyName", propertyInfo.CompanyId);
            ViewData["FieldId"] = new SelectList(_context.Fields, "Id", "FieldName", propertyInfo.FieldId);
            ViewData["OperatingAreaId"] = new SelectList(_context.OperatingAreas, "Id", "AreaName", propertyInfo.OperatingAreaId);
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "PropertyName", propertyInfo.PropertyId);
            return View(propertyInfo);
        }

        // POST: PropertyInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UniqueId,MapId,Rural,Dls,LocationLat,LocationLong,Address,City,ZipCode,Country,State,CompanyId,OperatingAreaId,FieldId,PropertyId,IsActive,CreatedOn,UpdatedOn")] PropertyInfo propertyInfo)
        {
            if (id != propertyInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propertyInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyInfoExists(propertyInfo.Id))
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
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "CompanyName", propertyInfo.CompanyId);
            ViewData["FieldId"] = new SelectList(_context.Fields, "Id", "FieldName", propertyInfo.FieldId);
            ViewData["OperatingAreaId"] = new SelectList(_context.OperatingAreas, "Id", "AreaName", propertyInfo.OperatingAreaId);
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "PropertyName", propertyInfo.PropertyId);
            return View(propertyInfo);
        }

        // GET: PropertyInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyInfo = await _context.PropertyInfos
                .Include(p => p.Company)
                .Include(p => p.Field)
                .Include(p => p.OperatingArea)
                .Include(p => p.Property)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propertyInfo == null)
            {
                return NotFound();
            }

            return View(propertyInfo);
        }

        // POST: PropertyInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propertyInfo = await _context.PropertyInfos.FindAsync(id);
            _context.PropertyInfos.Remove(propertyInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyInfoExists(int id)
        {
            return _context.PropertyInfos.Any(e => e.Id == id);
        }
    }
}
