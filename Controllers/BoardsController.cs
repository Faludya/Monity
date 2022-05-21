#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Monity.Models;
using Monity.Services.Interfaces;

namespace Monity.Controllers
{
    public class BoardsController : Controller
    {
        private readonly MonityContext _context;
        private readonly IBoardService _boardService;

        public BoardsController(MonityContext context, IBoardService boardService)
        {
            _context = context;
            this._boardService = boardService;
        }

        public IActionResult Index(int userId)
        {
            return View(_boardService.GetBoardsByUserId(userId));
        }

        public IActionResult Details(int id)
        {
            var board = _boardService.GetBoardById(id);

            if (board == null)
            {
                return NotFound();
            }

            return View(board);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] Board board)
        {
            _boardService.CreateBoard(board, 1);
            return RedirectToAction("Menu", "Home");
        }

        public IActionResult Edit(int id)
        {
            var board = _boardService.GetBoardById(id);
            if (board == null)
            {
                return NotFound();
            }
            return View(board);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreationDate")] Board board)
        {
            if (id != board.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _boardService.UpdateBoard(board);;
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction("Menu", "Home");
            }
            return View(board);
        }

        public IActionResult Delete(int id)
        {
            var board = _boardService.GetBoardById(id);
            if (board == null)
            {
                return NotFound();
            }

            return View(board);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _boardService.DeleteBoard(_boardService.GetBoardById(id));

            return RedirectToAction("Menu", "Home");
        }
    }
}
