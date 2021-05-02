using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TakeAction.Data;
using TakeAction.Models;
using TakeAction.Services;
using static TakeAction.Data.Employee;

namespace TakeAction.WebMVC.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Employee
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EmployeeService(userId);
            var model = service.GetEmployees();

            return View(model);
        }

        public ActionResult Create()
        {
            ViewData["Managers"] = _db.Managers.Select(m => new SelectListItem
            {
                Text = m.ManagerFirstName + " " + m.ManagerLastName,
                Value = m.ManagerId.ToString()
            });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeCreate model)
        {
            var service = CreateEmployeeService();
            //service.CreateEmployee(model);
            if (service.CreateEmployee(model))
            {
                TempData["SaveResult"] = "The Employee was created successfully!";
                return RedirectToAction(nameof(Index));
            }
            //if(_db.SaveChanges() == 1)
            //{
            //    return RedirectToAction("Index");
            //}

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateEmployeeService();
            var model = svc.GetEmployeeById(id);

            return View(model);
        }

        public ActionResult DetailsByManagerId(int managerId)
        {
            var svc = CreateEmployeeService();
            var model = svc.GetEmployeesByManagerId(managerId);

            return View(model);
        }

        public ActionResult DetailsByDept(Department dept)
        {
            var svc = CreateEmployeeService();
            var model = svc.GetEmployeesByDept(dept);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            ViewData["Managers"] = _db.Managers.Select(e => new SelectListItem
            {
                Text = e.ManagerFirstName + " " + e.ManagerLastName,
                Value = e.ManagerId.ToString()
            });
            var service = CreateEmployeeService();

            var detail = service.GetEmployeeById(id);

            var model =

                new EmployeeEdit
                {
                    EmployeeId = detail.EmployeeId,
                    EmployeeFirstName = detail.EmployeeFirstName,
                    EmployeeLastName = detail.EmployeeLastName,
                    ManagerId = detail.ManagerId,
                    ManagerFullName = detail.ManagerFullName,
                    HiredDate = detail.HiredDate,
                    Dept = detail.Dept,
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeEdit model)
        {
            //if (!ModelState.IsValid) return View(model);

            //if(model.EmployeeId != id)
            //{
            //    ModelState.AddModelError("", "Incorrect Id");
            //    return View(model); 
            //}

            var service = CreateEmployeeService();

            if(service.UpdateEmployee(model))

            {
                TempData["SaveResult"] = "The Employee was updated successfully!";
                return RedirectToAction("Index");
            }

            //ModelState.AddModelError("", "The Employee was not updated!");

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateEmployeeService();
            var model = svc.GetEmployeeById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateEmployeeService();

            service.DeleteEmployee(id);

            TempData["SaveResult"] = "The Employee was deleted!";

            return RedirectToAction("Index");
        }

        private EmployeeService CreateEmployeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EmployeeService(userId);
            return service;
        }


    }

    
}