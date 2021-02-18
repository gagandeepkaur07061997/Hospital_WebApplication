using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital_WebApplication.Data;
using Hospital_WebApplication.Models;

namespace Hospital_WebApplication.Controllers
{
    public class CompanydetailsController : Controller
    {
        private readonly Hospital_WebApplicationDatabase _context;

        public CompanydetailsController(Hospital_WebApplicationDatabase context)
        {
            _context = context;
        }

        // GET: Companydetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.Companydetail.ToListAsync());
        }

        // GET: Companydetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companydetail = await _context.Companydetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companydetail == null)
            {
                return NotFound();
            }

            return View(companydetail);
        }

        // GET: Companydetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companydetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email_Id,Address,Mobile_Number,Website")] Companydetail companydetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companydetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companydetail);
        }

        // GET: Companydetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companydetail = await _context.Companydetail.FindAsync(id);
            if (companydetail == null)
            {
                return NotFound();
            }
            return View(companydetail);
        }

        // POST: Companydetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email_Id,Address,Mobile_Number,Website")] Companydetail companydetail)
        {
            if (id != companydetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companydetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanydetailExists(companydetail.Id))
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
            return View(companydetail);
        }

        // GET: Companydetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companydetail = await _context.Companydetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companydetail == null)
            {
                return NotFound();
            }

            return View(companydetail);
        }

        // POST: Companydetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companydetail = await _context.Companydetail.FindAsync(id);
            _context.Companydetail.Remove(companydetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanydetailExists(int id)
        {
            return _context.Companydetail.Any(e => e.Id == id);
        }
    }
}
