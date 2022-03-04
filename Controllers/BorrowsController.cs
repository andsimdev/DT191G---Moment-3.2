#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DT191G___Moment_3._2.Data;
using DT191G___Moment_3._2.Models;
using Microsoft.Data.Sqlite;

namespace DT191G___Moment_3._2.Controllers
{
    public class BorrowsController : Controller
    {
        private readonly CdContext _context;

        public BorrowsController(CdContext context)
        {
            _context = context;
        }

        // GET: Borrows
        public async Task<IActionResult> Index()
        {
            var cdContext = _context.Borrows.Include(b => b.Cd).Include(b => b.User);
            return View(await cdContext.ToListAsync());
        }

        // GET: Borrows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrow = await _context.Borrows
                .Include(b => b.Cd)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BorrowId == id);
            if (borrow == null)
            {
                return NotFound();
            }

            return View(borrow);
        }

        // GET: Borrows/Create
        public IActionResult Create()
        {
            ViewData["CdId"] = new SelectList(_context.Cds, "CdId", "CdName");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserName");
            return View();
        }

        // POST: Borrows/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BorrowId,UserId,CdId,BorrowDate")] Borrow borrow)
        {
            // Kontrollera om CD-skivan redan är utlånad
            // Hämta medskickat CD-id
            int sentId = borrow.CdId;

            // Formulera fråga mot databasen
            var check = from b in _context.Borrows
                        select b;
            check = check.Where(b => b.CdId!.Equals(sentId));

            // Skicka frågan och kolla om skivan finns. Denna är null om skivan är ledig
            var result = check.FirstOrDefault();

            // Om skivan är ledig
            if (result == null)
            {
                // Kontrollera formuläret och lagra till databasen
                if (ModelState.IsValid)
                {
                    _context.Add(borrow);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            // Annars om skivan är utlånad, skicka felmeddelande till vyn
            else
            {
                ViewBag.Error = "Skivan är redan utlånad";
                ViewData["CdId"] = new SelectList(_context.Cds, "CdId", "CdName", borrow.CdId);
                ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserName", borrow.UserId);
                return View(borrow);
            }
            ViewData["CdId"] = new SelectList(_context.Cds, "CdId", "CdName", borrow.CdId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserName", borrow.UserId);
            return View(borrow);
        }

        // GET: Borrows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrow = await _context.Borrows.FindAsync(id);
            if (borrow == null)
            {
                return NotFound();
            }
            ViewData["CdId"] = new SelectList(_context.Cds, "CdId", "CdName", borrow.CdId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserName", borrow.UserId);
            return View(borrow);
        }

        // POST: Borrows/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BorrowId,UserId,CdId,BorrowDate")] Borrow borrow)
        {
            if (id != borrow.BorrowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowExists(borrow.BorrowId))
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
            ViewData["CdId"] = new SelectList(_context.Cds, "CdId", "CdName", borrow.CdId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserName", borrow.UserId);
            return View(borrow);
        }

        // GET: Borrows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrow = await _context.Borrows
                .Include(b => b.Cd)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BorrowId == id);
            if (borrow == null)
            {
                return NotFound();
            }

            return View(borrow);
        }

        // POST: Borrows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var borrow = await _context.Borrows.FindAsync(id);
            _context.Borrows.Remove(borrow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowExists(int id)
        {
            return _context.Borrows.Any(e => e.BorrowId == id);
        }
    }
}
