using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monity.Models;
using Monity.Services;
using Monity.Services.Interfaces;
using Monity.ViewModels;
using System.Diagnostics;

namespace Monity.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBoardViewModelService _boardService;
        public HomeController(IBoardViewModelService boardService)
        {
            this._boardService = boardService;
        }

        public IActionResult Index([FromServices] ILog log)
        {
            log.Info("Executing /Home/Index");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        public IActionResult Menu(int selectedBoardId)
        {
            if(selectedBoardId == 0)
            {
                var temp = _boardService.GetBoardViewModel();
                TempData["BoardId"] = temp.SelectedBoard.Board.Id;

                return View(temp);
            }
            else
            {
                var boardsViewModel = _boardService.GetBoardViewModel();
                boardsViewModel.SelectedBoard = _boardService.GetBoardContainer(selectedBoardId);
                return View(boardsViewModel);
            }
        }

        //[Authorize(Roles = "User")]
        //[HttpPut]
        //public IActionResult Menu(Board board)
        //{
        //    var boardsViewModel = _boardService.GetBoardViewModel();
        //    boardsViewModel.SelectedBoard = _boardService.GetBoardContainer(board);
        //    return View(boardsViewModel);
        //}

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult Menu(string overdue)
        {
            return View(_boardService.GetBoardViewModel(overdue));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}