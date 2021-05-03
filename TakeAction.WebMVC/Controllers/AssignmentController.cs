using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TakeAction.Data;
using TakeAction.Models.Assignment;
using TakeAction.Services;

namespace TakeAction.WebMVC.Controllers
{
    [Authorize]
    public class AssignmentController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Assignment
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AssignmentService(userId);
            var model = service.GetAssignments();

            return View(model);
        }

        public ActionResult Create()
        {
            ViewData["Employees"] = _db.Employees.Select(e => new SelectListItem
            {
                Text = e.EmployeeFirstName + " " + e.EmployeeLastName,
                Value = e.EmployeeId.ToString()
            });
            ViewData["Tasks"] = _db.Tasks.Select(e => new SelectListItem
            {
                Text = e.TaskName,
                Value = e.TaskId.ToString()
            });
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssignmentCreate model)
        {
            //if (!ModelState.IsValid) return View(model);

            var service = CreateAssignmentService();

            if (service.CreateAssignment(model))
            {
                TempData["SaveResult"] = "The assignment was created successfully!";
                return RedirectToAction("Index");
            };

            //ModelState.AddModelError("", "The assignment could not be created!");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateAssignmentService();
            var model = svc.GetAssignmentById(id);

            return View(model);
        }

        public ActionResult DetailsByEmployeeId(int employeeId)
        {
            var svc = CreateAssignmentService();
            var model = svc.GetAssignmentsByEmployeeId(employeeId);

            return View(model);
        }

        public ActionResult FlaggedAssignments()
        {
            var svc = CreateAssignmentService();
            var model = svc.GetFlaggedAssignments();

            return View(model);
        }

        public ActionResult UnflaggedAssignments()
        {
            var svc = CreateAssignmentService();
            var model = svc.GetUnflaggedAssignments();

            return View(model);
        }

        public ActionResult CompletedAssignments()
        {
            var svc = CreateAssignmentService();
            var model = svc.GetCompletedAssignments();

            return View(model);
        }

        public ActionResult OutstandingAssignments()
        {
            var svc = CreateAssignmentService();
            var model = svc.GetOutstandingAssignments();

            return View(model);
        }

        public ActionResult DetailsByDueDate(DateTimeOffset? dueDate)
        {
            var svc = CreateAssignmentService();
            var model = svc.GetAssignmentsByDueDate(dueDate);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            ViewData["Employees"] = _db.Employees.Select(e => new SelectListItem
            {
                Text = e.EmployeeFirstName + " " + e.EmployeeLastName,
                Value = e.EmployeeId.ToString()
            });
            ViewData["Tasks"] = _db.Tasks.Select(e => new SelectListItem
            {
                Text = e.TaskName,
                Value = e.TaskId.ToString()
            });
            var service = CreateAssignmentService();
            var detail = service.GetAssignmentById(id);
            var model =
                new AssignmentEdit
                {
                    EmployeeId = detail.EmployeeId,
                    EmployeeFullName = detail.EmployeeFullName,
                    TaskId = detail.TaskId,
                    TaskName = detail.TaskName,
                    DueDate = detail.DueDate,
                    AssignmentId = detail.AssignmentId,
                    AssignerFirstName = detail.AssignerFirstName,
                    AssignerLastName = detail.AssignerLastName,
                    DeptA = detail.DeptA,
                    AssignedDate = detail.AssignedDate,
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AssignmentEdit model)
        {
            //if (!ModelState.IsValid) return View(model);

            //if (model.AssignmentId != id)
            //{
            //    ModelState.AddModelError("", "Id Mismatch");
            //    return View(model);
            //}

            //var service = CreateAssignmentService();

            //if (service.UpdateAssignment(model))
            //{
            //    TempData["SaveResult"] = "The assignment was updated!";
            //    return RedirectToAction("Index");
            //}

            //ModelState.AddModelError("", "The assignment could not be updated!");
            //return View(model);
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}
            var service = CreateAssignmentService();

            if (service.UpdateAssignment(model))
            {
                TempData["SaveResult"] = "The Assignment was updated successfully!";
                return RedirectToAction("Index");
            };

            //ModelState.AddModelError("", "The assignment could not be created!");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAssignmentService();
            var model = svc.GetAssignmentById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAssignment(int id)
        {
            var service = CreateAssignmentService();

            service.DeleteAssignment(id);

            TempData["SaveResult"] = "The assignment was deleted!";

            return RedirectToAction("Index");
        }


        private AssignmentService CreateAssignmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AssignmentService(userId);
            return service;
        }
    }
}