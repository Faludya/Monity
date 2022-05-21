#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Monity.Models;

namespace Monity.Controllers
{
    public class UserBoardsController : Controller
    {
        private readonly MonityContext _context;

        public UserBoardsController(MonityContext context)
        {
            _context = context;
        }

        // GET: UserBoards
        public async Task<IActionResult> Index()
        {
            var monityContext = _context.UserBoards.Include(u => u.Board);
            return View(await monityContext.ToListAsync());
        }

        // GET: UserBoards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userBoard = await _context.UserBoards
                .Include(u => u.Board)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userBoard == null)
            {
                return NotFound();
            }

            return View(userBoard);
        }

        // GET: UserBoards/Create
        public IActionResult Create()
        {
            ViewData["BoardId"] = new SelectList(_context.Boards, "Id", "Id");
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: UserBoards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,BoardId")] UserBoard userBoard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userBoard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BoardId"] = new SelectList(_context.Boards, "Id", "Id", userBoard.BoardId);
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userBoard.UserId);
            return View(userBoard);
        }

        // GET: UserBoards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userBoard = await _context.UserBoards.FindAsync(id);
            if (userBoard == null)
            {
                return NotFound();
            }
            ViewData["BoardId"] = new SelectList(_context.Boards, "Id", "Id", userBoard.BoardId);
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userBoard.UserId);
            return View(userBoard);
        }

        // POST: UserBoards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,BoardId")] UserBoard userBoard)
        {
            if (id != userBoard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userBoard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserBoardExists(userBoard.Id))
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
            ViewData["BoardId"] = new SelectList(_context.Boards, "Id", "Id", userBoard.BoardId);
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userBoard.UserId);
            return View(userBoard);
        }

        // GET: UserBoards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userBoard = await _context.UserBoards
                .Include(u => u.Board)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userBoard == null)
            {
                return NotFound();
            }

            return View(userBoard);
        }

        // POST: UserBoards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userBoard = await _context.UserBoards.FindAsync(id);
            _context.UserBoards.Remove(userBoard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserBoardExists(int id)
        {
            return _context.UserBoards.Any(e => e.Id == id);
        }
    }
}
