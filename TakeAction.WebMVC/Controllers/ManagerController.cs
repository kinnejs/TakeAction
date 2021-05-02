using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TakeAction.Data;
using TakeAction.Models.Manager;
using TakeAction.Services;
using static TakeAction.Data.Employee;
using static TakeAction.Data.Manager;

namespace TakeAction.WebMVC.Controllers
{
    [Authorize]
    public class ManagerController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Manager
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ManagerService(userId);
            var svc = CreateManagerService();
            var model = svc.GetManagers();
            foreach(var manager in model)
            {
                manager.Subordinates = svc.GetEmployeeCountIndex(manager);  
            }
            
            


            return View(model);
        }

        public ActionResult Create()
        {
            ViewData["Managers"] = _db.Managers.Select(m => new SelectListItem
            {
                Text = m.ManagerFullName,
                Value = m.ManagerId.ToString()
            });


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ManagerCreate model)
        {
            

            var service = CreateManagerService();

            if (service.CreateManager(model))
            {
                TempData["SaveResult"] = "The Manager was created successfully!";
                return RedirectToAction(nameof(Index));
            };

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateManagerService();
            var model = svc.GetManagerById(id);
            model.Subordinates = svc.GetEmployeeCount(model);
            return View(model);
        }

        public ActionResult DetailsByDept(DepartmentM dept)
        {
            var svc = CreateManagerService();
            var model = svc.GetManagersByDept(dept);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateManagerService();
            var detail = service.GetManagerById(id);
            var model =
                new ManagerEdit
                {
                    ManagerId = detail.ManagerId,
                    ManagerFirstName = detail.ManagerFirstName,
                    ManagerLastName = detail.ManagerLastName,
                    ManagerFullName = detail.ManagerFullName,
                    HiredDate = detail.HiredDate,
                    DeptM = detail.DeptM,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ManagerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            //if(model.ManagerId != id)
            //{
            //    ModelState.AddModelError("", "Id Mismatch");
            //    return View(model);
            //}

            var service = CreateManagerService();

            if (service.UpdateManager(model))
            {
                TempData["SaveResult"] = "The manager was updated!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The manager could not be updated!");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateManagerService();
            var model = svc.GetManagerById(id);
            model.Subordinates = svc.GetEmployeeCount(model);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateManagerService();

            service.DeleteManager(id);

            TempData["SaveResult"] = "The manager was successfully deleted!";

            return RedirectToAction("Index");
        }

        private ManagerService CreateManagerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ManagerService(userId);
            return service;
        }
    }
}