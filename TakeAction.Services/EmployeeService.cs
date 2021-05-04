using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAction.Data;
using TakeAction.Models;
using TakeAction.Models.Employee;
using TakeAction.Models.Manager;
using static TakeAction.Data.Employee;

namespace TakeAction.Services
{
    public class EmployeeService
    {
        private readonly Guid _userId;

        public EmployeeService(Guid userId)
        {
            _userId = userId;
        }



        public bool CreateEmployee(EmployeeCreate model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var managerName = ctx.Managers.Find(model.ManagerId);
                var entity =

                    new Employee()
                    {
                        EmployeeOwnerId = _userId,
                        OwnerId = _userId,
                        EmployeeFirstName = model.EmployeeFirstName,
                        EmployeeLastName = model.EmployeeLastName,
                        ManagerId = model.ManagerId,
                        HiredDate = model.HiredDate,
                        Dept = model.Dept,
                    };
                ctx.Employees.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EmployeeListItem> GetEmployees()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx

                        .Employees
                        .Where(e => e.EmployeeOwnerId == _userId)
                        .Select(
                            e =>
                                new EmployeeListItem
                                {
                                    EmployeeId = e.EmployeeId,
                                    EmployeeFirstName = e.EmployeeFirstName,
                                    EmployeeLastName = e.EmployeeLastName,
                                    ManagerFirstName = e.Manager.ManagerFirstName,
                                    ManagerLastName = e.Manager.ManagerLastName,
                                    HiredDate = e.HiredDate,
                                    Dept = e.Dept,
                                }
                         );
                return query.ToArray();
            }
        }



        public EmployeeDetail GetEmployeeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Employees
                        .Single(e => e.EmployeeId == id && e.EmployeeOwnerId == _userId);

                return
                    new EmployeeDetail
                    {
                        EmployeeId = entity.EmployeeId,
                        EmployeeFirstName = entity.EmployeeFirstName,
                        EmployeeLastName = entity.EmployeeLastName,
                        ManagerFirstName = entity.Manager.ManagerFirstName,
                        ManagerLastName = entity.Manager.ManagerLastName,
                        HiredDate = entity.HiredDate,
                        ManagerId = entity.ManagerId,
                        Dept = entity.Dept,

                    };
            }
        }

        public IEnumerable<EmployeeDetailTwo> GetEmployeesByManagerId(int? managerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Employees
                        .Where(e => e.ManagerId == managerId)
                        .Select(e => new EmployeeDetailTwo
                        {
                            EmployeeId = e.EmployeeId,
                            EmployeeFirstName = e.EmployeeFirstName,
                            EmployeeLastName = e.EmployeeLastName,
                            ManagerId = e.ManagerId,
                            HiredDate = e.HiredDate,
                            Dept = e.Dept,
                        });
                return query.ToArray();
            }
        }

        public IEnumerable<EmployeeDetailTwo> GetEmployeesByDept(Department dept)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Employees
                        .Where(e => e.Dept == dept)
                        .Select(e => new EmployeeDetailTwo
                        {
                            EmployeeId = e.EmployeeId,
                            EmployeeFirstName = e.EmployeeFirstName,
                            EmployeeLastName = e.EmployeeLastName,
                            ManagerId = e.ManagerId,
                            HiredDate = e.HiredDate,
                            Dept = e.Dept,
                        });
                return query.ToArray();
            }
        }


        public bool UpdateEmployee(EmployeeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var employeeName = ctx.Employees.Find(model.EmployeeId);
                var managerName = ctx.Managers.Find(model.ManagerId);

                var entity =
                    ctx
                        .Employees
                        .Single(e => e.EmployeeId == model.EmployeeId && e.EmployeeOwnerId == _userId);

                entity.EmployeeFirstName = model.EmployeeFirstName;
                entity.EmployeeLastName = model.EmployeeLastName;
                entity.HiredDate = model.HiredDate;
                entity.ManagerId = model.ManagerId;
                entity.Dept = model.Dept;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEmployee(int employeeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Employees
                        .Single(e => e.EmployeeId == employeeId && e.OwnerId == _userId);
                var entity2 =
                    ctx
                        .Assignments
                        .Where(e => e.EmployeeId == employeeId);
                foreach(var item in entity2)
                {
                    item.EmployeeId = null;
                }

                ctx.Employees.Remove(entity);
                var assignmentCount = entity2.Count();
                return ctx.SaveChanges() == assignmentCount + 1;
            }
        }


    }
}
