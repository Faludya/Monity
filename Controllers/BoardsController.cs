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
using Monity.Services.Interfaces;

namespace Monity.Controllers
{

    [Authorize(Roles = "Admin,User")]
    public class BoardsController : Controller
    {
        private readonly IBoardService _boardService;

        public BoardsController( IBoardService boardService)
        {
            this._boardService = boardService;
        }

        public IActionResult Index(int userId)
        {
            return View(_boardService.GetBoardsByUserId(userId));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminIndex()
        {
            return View(_boardService.GetAllBoards());
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

        [Authorize(Roles = "Admin, User")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] Board board)
        {
            _boardService.CreateBoard(board, 1);
            return RedirectToAction("Menu", "Home");
        }

        [Authorize(Roles = "Admin, User")]
        public IActionResult Edit(int id)
        {
            var board = _boardService.GetBoardById(id);
            if (board == null)
            {
                return NotFound();
            }
            return View(board);
        }

        [Authorize(Roles = "Admin, User")]
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

        [Authorize(Roles = "Admin, User")]
        public IActionResult Delete(int id)
        {
            var board = _boardService.GetBoardById(id);
            if (board == null)
            {
                return NotFound();
            }

            return View(board);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _boardService.DeleteBoard(_boardService.GetBoardById(id));

            return RedirectToAction("Menu", "Home");
        }
    }
}
