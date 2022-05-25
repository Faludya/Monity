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
    [Authorize(Roles = "User")]
    public class UserBoardsController : Controller
    {
        private readonly IUserBoardService _userBoardService;
        private readonly IUserService _userService;
        public UserBoardsController(IUserBoardService userBoardService, IUserService userService)
        {
            _userBoardService = userBoardService;
            _userService = userService;
        }

        public IActionResult Index(int boardId)
        {
            var test = _userService.GetUsersOfBoard(boardId);
            return View(test);
        }

        public IActionResult Details(int id)
        {
            var userBoard = _userBoardService.GetUserBoardById(id);

            if (userBoard == null)
            {
                return NotFound();
            }

            return View(userBoard);
        }

        public IActionResult Create(int boardId)
        {
            ViewData["BoardId"] = boardId;
            ViewData["UserId"] = new SelectList(_userService.GetAllUsers(), "Id", "Email");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,UserId,BoardId")] UserBoard userBoard)
        {
            if (ModelState.IsValid)
            {
                _userBoardService.CreateUserBoard(userBoard);
                return RedirectToAction("Menu", "Home", new { selectedBoardId = userBoard.BoardId });
            }
            ViewData["BoardId"] = userBoard.BoardId;
            ViewData["UserId"] = new SelectList(_userService.GetAllUsers(), "Id", "Email");
            return View(userBoard);
        }

        //public IActionResult Delete(string userId)
        //{
        //    var boardId = (int)TempData["RemoveUserBoardId"];

        //    var userBoard = _userBoardService.GetUserBoardByUserAndBoardId(userId, boardId);

        //    if (userBoard == null)
        //    {
        //        return NotFound();
        //    }


        //    _userBoardService.DeleteUserBoard(userBoard);

        //    return RedirectToAction("Menu", "Home", new { selectedBoardId = boardId });
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    var userBoard = _userBoardService.GetUserBoardById(id);
        //    _userBoardService.DeleteUserBoard(userBoard);

        //    return RedirectToAction("Menu", "Home", new { selectedBoardId = id});
        //}
    }
}
