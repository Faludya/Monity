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
    public class UserTasksController : Controller
    {
        private readonly IUserTaskService _userTaskService;

        public UserTasksController(IUserTaskService userTaskService)
        {
            _userTaskService = userTaskService;
        }

        public IActionResult Details(int id)
        {
            var userTask = _userTaskService.GetUserTaskInclude(id);

            if (userTask == null)
            {
                return NotFound();
            }

            return View(userTask);
        }

        public IActionResult Create(int boardId)
        {
            ViewData["StatusId"] = new SelectList(_userTaskService.GetBoardStatuses(boardId), "Id", "Id");
            var newTask = new UserTask()
            {
                BoardId = boardId,
            };

            return View(newTask);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Description,DueDate,StatusId,BoardId")] UserTask userTask)
        {
            if (ModelState.IsValid)
            {
                _userTaskService.CreateTask(userTask);
                return RedirectToAction("Menu", "Home");
            }

            var boardStatuses = _userTaskService.GetBoardStatuses(userTask.BoardId);
            ViewData["StatusId"] = new SelectList(boardStatuses, "Id", "Id", userTask.StatusId);
            return View(userTask);
        }

        public IActionResult Edit(int id)
        {
            var userTask = _userTaskService.GetUserTaskInclude(id);
            var boardStatuses = _userTaskService.GetBoardStatuses(userTask.BoardId);

            if (userTask == null)
            {
                return NotFound();
            }

            ViewData["StatusId"] = new SelectList(boardStatuses, "Id", "Id", userTask.StatusId);

            return View(userTask);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id, Title, Description, DueDate, StatusId, BoardId")] UserTask userTask)
        {
            if (id != userTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _userTaskService.UpdateTask(userTask);
                }
                catch (DbUpdateConcurrencyException)
                {
                }

                return RedirectToAction("Menu", "Home");
            }

            var boardStatuses = _userTaskService.GetBoardStatuses(userTask.BoardId);
            ViewData["StatusId"] = new SelectList(boardStatuses, "Id", "Id", userTask.StatusId);
            return View(userTask);
        }

        public IActionResult Delete(int id)
        {
            var userTask = _userTaskService.GetUserTaskInclude(id);

            if (userTask == null)
            {
                return NotFound();
            }

            return View(userTask);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var userTask =  _userTaskService.GetUserTask(id);
            _userTaskService.DeleteTask(userTask);

            return RedirectToAction("Menu", "Home");
        }
    }
}
