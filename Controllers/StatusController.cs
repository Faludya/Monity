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
    public class StatusController : Controller
    {
        private readonly IStatusService _statusService;
        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        public IActionResult Index(int boardId)
        {
            return View(_statusService.GetStatusesByBoardId(boardId));
        }

        public IActionResult Details(int id)
        {
            var status = _statusService.GetStatusById(id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description")] Status status)
        {
            if (ModelState.IsValid)
            {
                var boardId = (int)TempData["BoardId"];
                _statusService.CreateStatus(status, boardId);
                return RedirectToAction("Menu", "Home", new { selectedBoardId = boardId});
            }
            return View(status);
        }

        public IActionResult Edit(int id)
        {
            var status = _statusService.GetStatusById(id);
            if (status == null)
            {
                return NotFound();
            }
            return View(status);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, [Bind("Id,Name,Description")] Status status)
        {
            if (id != status.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _statusService.UpdateStatus(status);
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                var boardId = (int)TempData["BoardId"];
                return RedirectToAction("Menu", "Home", new { selectedBoardId = boardId });
            }
            return View(status);
        }

        public IActionResult Delete(int id)
        {
            var status = _statusService.GetStatusById(id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _statusService.DeleteStatus(_statusService.GetStatusById(id));
            var boardId = (int)TempData["BoardId"];
            return RedirectToAction("Menu", "Home", new { selectedBoardId = boardId });
        }
    }
}
