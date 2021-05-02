using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TakeAction.Data;
using TakeAction.Models.Task;
using TakeAction.Services;

namespace TakeAction.WebMVC.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Task
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TaskService(userId);
            var model = service.GetTasks();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTaskService();

            if(service.CreateTask(model))
            {
                TempData["SaveResult"] = "Your task was created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The task could not be created!");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTaskService();
            var model = svc.GetTaskById(id);

            return View(model);
        }

        public ActionResult DetailsCompletedTasks(bool complete)
        {
            var svc = CreateTaskService();
            var model = svc.GetCompletedTasks(complete);

            return View(model);
        }

        public ActionResult DetailsFlaggedTasks(bool flagged)
        {
            var svc = CreateTaskService();
            var model = svc.GetFlaggedTasks(flagged);

            return View(model);
        }

        public ActionResult DetailsOutstandingTasks(bool outstanding)
        {
            var svc = CreateTaskService();
            var model = svc.GetOutstandingTasks(outstanding);

            return View(model);
        }

        public ActionResult DetailsByDueDate(DateTimeOffset? dueDate)
        {
            var svc = CreateTaskService();
            var model = svc.GetTasksByDueDate(dueDate);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTaskService();
            var detail = service.GetTaskById(id);
            var model =
                new TaskEdit
                {
                    TaskId = detail.TaskId,
                    TaskName = detail.TaskName,
                    TaskSummary = detail.TaskSummary,
                    DueDate = detail.DueDate,
                    Flagged = detail.Flagged,
                    Completed = detail.Completed,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.TaskId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTaskService();

            if(service.UpdateTask(model))
            {
                TempData["SaveResult"] = "Your task was updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated!");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTaskService();
            var model = svc.GetTaskById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTask(int id)
        {
            var service = CreateTaskService();

            service.DeleteTask(id);

            TempData["SaveResult"] = "Your task was deleted!";

            return RedirectToAction("Index");
        }


        private TaskService CreateTaskService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TaskService(userId);
            return service;
        }
    }
}