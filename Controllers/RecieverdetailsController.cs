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
    public class RecieverdetailsController : Controller
    {
        private readonly Hospital_WebApplicationDatabase _context;

        public RecieverdetailsController(Hospital_WebApplicationDatabase context)
        {
            _context = context;
        }

        // GET: Recieverdetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recieverdetail.ToListAsync());
        }

        // GET: Recieverdetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recieverdetail = await _context.Recieverdetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recieverdetail == null)
            {
                return NotFound();
            }

            return View(recieverdetail);
        }

        // GET: Recieverdetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recieverdetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email_Id,Address,Mobile_Number")] Recieverdetail recieverdetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recieverdetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recieverdetail);
        }

        // GET: Recieverdetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recieverdetail = await _context.Recieverdetail.FindAsync(id);
            if (recieverdetail == null)
            {
                return NotFound();
            }
            return View(recieverdetail);
        }

        // POST: Recieverdetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email_Id,Address,Mobile_Number")] Recieverdetail recieverdetail)
        {
            if (id != recieverdetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recieverdetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecieverdetailExists(recieverdetail.Id))
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
            return View(recieverdetail);
        }

        // GET: Recieverdetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recieverdetail = await _context.Recieverdetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recieverdetail == null)
            {
                return NotFound();
            }

            return View(recieverdetail);
        }

        // POST: Recieverdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recieverdetail = await _context.Recieverdetail.FindAsync(id);
            _context.Recieverdetail.Remove(recieverdetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecieverdetailExists(int id)
        {
            return _context.Recieverdetail.Any(e => e.Id == id);
        }
    }
}
