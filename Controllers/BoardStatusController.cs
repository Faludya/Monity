#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Monity.Models;

namespace Monity.Controllers
{
    [Authorize(Roles = "User")]
    public class BoardStatusController : Controller
    {
        private readonly MonityContext _context;

        public BoardStatusController(MonityContext context)
        {
            _context = context;
        }

        // GET: BoardStatus
        public async Task<IActionResult> Index()
        {
            var monityContext = _context.BoardStatuses.Include(b => b.Board).Include(b => b.Status);
            return View(await monityContext.ToListAsync());
        }

        // GET: BoardStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boardStatus = await _context.BoardStatuses
                .Include(b => b.Board)
                .Include(b => b.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boardStatus == null)
            {
                return NotFound();
            }

            return View(boardStatus);
        }

        // GET: BoardStatus/Create
        public IActionResult Create()
        {
            ViewData["BoardId"] = new SelectList(_context.Boards, "Id", "Id");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Id");
            return View();
        }

        // POST: BoardStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BoardId,StatusId")] BoardStatus boardStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boardStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BoardId"] = new SelectList(_context.Boards, "Id", "Id", boardStatus.BoardId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Id", boardStatus.StatusId);
            return View(boardStatus);
        }

        // GET: BoardStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boardStatus = await _context.BoardStatuses.FindAsync(id);
            if (boardStatus == null)
            {
                return NotFound();
            }
            ViewData["BoardId"] = new SelectList(_context.Boards, "Id", "Id", boardStatus.BoardId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Id", boardStatus.StatusId);
            return View(boardStatus);
        }

        // POST: BoardStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BoardId,StatusId")] BoardStatus boardStatus)
        {
            if (id != boardStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boardStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoardStatusExists(boardStatus.Id))
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
            ViewData["BoardId"] = new SelectList(_context.Boards, "Id", "Id", boardStatus.BoardId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Id", boardStatus.StatusId);
            return View(boardStatus);
        }

        // GET: BoardStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boardStatus = await _context.BoardStatuses
                .Include(b => b.Board)
                .Include(b => b.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boardStatus == null)
            {
                return NotFound();
            }

            return View(boardStatus);
        }

        // POST: BoardStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boardStatus = await _context.BoardStatuses.FindAsync(id);
            _context.BoardStatuses.Remove(boardStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoardStatusExists(int id)
        {
            return _context.BoardStatuses.Any(e => e.Id == id);
        }
    }
}
