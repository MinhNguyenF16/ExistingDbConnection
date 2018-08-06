using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExistingDbConnection.Models;

namespace ExistingDbConnection.Controllers
{
    public class CryptoesController : Controller
    {
        private readonly coreDBContext _context;

        public CryptoesController(coreDBContext context)
        {
            _context = context;
        }

        // GET: Cryptoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Crypto.ToListAsync());
        }

        // GET: Cryptoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crypto = await _context.Crypto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crypto == null)
            {
                return NotFound();
            }

            return View(crypto);
        }

        // GET: Cryptoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cryptoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CryptoName,Type,Price,Country")] Crypto crypto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(crypto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(crypto);
        }

        // GET: Cryptoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crypto = await _context.Crypto.FindAsync(id);
            if (crypto == null)
            {
                return NotFound();
            }
            return View(crypto);
        }

        // POST: Cryptoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CryptoName,Type,Price,Country")] Crypto crypto)
        {
            if (id != crypto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(crypto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CryptoExists(crypto.Id))
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
            return View(crypto);
        }

        // GET: Cryptoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crypto = await _context.Crypto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crypto == null)
            {
                return NotFound();
            }

            return View(crypto);
        }

        // POST: Cryptoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var crypto = await _context.Crypto.FindAsync(id);
            _context.Crypto.Remove(crypto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CryptoExists(int id)
        {
            return _context.Crypto.Any(e => e.Id == id);
        }
    }
}
