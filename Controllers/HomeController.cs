using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Monity.Models;
using Monity.Services;
using Monity.Services.Interfaces;
using Monity.ViewModels;
using System.Diagnostics;

namespace Monity.Controllers
{
    [Authorize(Roles = "User")]
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IBoardViewModelService _boardService;
        public HomeController(UserManager<IdentityUser> userManager, IBoardViewModelService boardService)
        {
            this._boardService = boardService;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Index([FromServices] ILog log)
        {
            log.Info("Executing /Home/Index");
            return View();
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        public IActionResult Menu(int selectedBoardId)
        {
            if(selectedBoardId == 0)
            {
                var temp = _boardService.GetBoardViewModel(_userManager.GetUserId(User));
                if(temp.SelectedBoard != null)
                {
                    TempData["BoardId"] = temp.SelectedBoard.Board.Id;
                    TempData["RemoveUserBoardId"] = temp.SelectedBoard.Board.Id;
                }
                return View(temp);
            }
            else
            {
                var boardsViewModel = _boardService.GetBoardViewModel(_userManager.GetUserId(User));
                boardsViewModel.SelectedBoard = _boardService.GetBoardContainer(selectedBoardId);
                TempData["BoardId"] = boardsViewModel.SelectedBoard.Board.Id;
                TempData["RemoveUserBoardId"] = boardsViewModel.SelectedBoard.Board.Id;

                return View(boardsViewModel);
            }
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult Menu(int selectedBoardId, string overdue)
        {
            TempData["BoardId"] = selectedBoardId;
            TempData["RemoveUserBoardId"] = selectedBoardId;
            return View(_boardService.GetBoardViewModel(selectedBoardId ,_userManager.GetUserId(User), overdue));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}