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
    public class SenderdetailsController : Controller
    {
        private readonly Hospital_WebApplicationDatabase _context;

        public SenderdetailsController(Hospital_WebApplicationDatabase context)
        {
            _context = context;
        }

        // GET: Senderdetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.Senderdetail.ToListAsync());
        }

        // GET: Senderdetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var senderdetail = await _context.Senderdetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (senderdetail == null)
            {
                return NotFound();
            }

            return View(senderdetail);
        }

        // GET: Senderdetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Senderdetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email_Id,Address,Mobile_Number")] Senderdetail senderdetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(senderdetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(senderdetail);
        }

        // GET: Senderdetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var senderdetail = await _context.Senderdetail.FindAsync(id);
            if (senderdetail == null)
            {
                return NotFound();
            }
            return View(senderdetail);
        }

        // POST: Senderdetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email_Id,Address,Mobile_Number")] Senderdetail senderdetail)
        {
            if (id != senderdetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(senderdetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SenderdetailExists(senderdetail.Id))
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
            return View(senderdetail);
        }

        // GET: Senderdetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var senderdetail = await _context.Senderdetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (senderdetail == null)
            {
                return NotFound();
            }

            return View(senderdetail);
        }

        // POST: Senderdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var senderdetail = await _context.Senderdetail.FindAsync(id);
            _context.Senderdetail.Remove(senderdetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SenderdetailExists(int id)
        {
            return _context.Senderdetail.Any(e => e.Id == id);
        }
    }
}
