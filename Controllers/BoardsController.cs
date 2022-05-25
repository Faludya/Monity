#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IBoardService _boardService;

        public BoardsController(UserManager<IdentityUser> userManager, IBoardService boardService)
        {
            this._boardService = boardService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_boardService.GetBoardsByUserId(_userManager.GetUserId(User)));
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] Board board)
        {
            var temp = _userManager.GetUserId(User);
            _boardService.CreateBoard(board, _userManager.GetUserId(User));
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
        public IActionResult Edit(int id, [Bind("Id,Name,CreationDate")] Board board)
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
