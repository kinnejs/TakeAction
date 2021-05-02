using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAction.Data;
using TakeAction.Models.Manager;
using static TakeAction.Data.Employee;
using static TakeAction.Data.Manager;

namespace TakeAction.Services
{
    public class ManagerService
    {
        private readonly Guid _userId;

        public ManagerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateManager(ManagerCreate model)
        {
            var entity =

                new Manager()
                {
                    ManagerOwnerId = _userId,
                    ManagerFirstName = model.ManagerFirstName,
                    ManagerLastName = model.ManagerLastName,
                    HiredDate = model.HiredDate,
                    DeptM = model.DeptM,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Managers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ManagerListItem> GetManagers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Managers
                        .Where(e => e.ManagerOwnerId == _userId)
                        .Select(
                            e =>
                                new ManagerListItem
                                {
                                    ManagerId = e.ManagerId,
                                    ManagerFirstName = e.ManagerFirstName,
                                    ManagerLastName = e.ManagerLastName,
                                    HiredDate = e.HiredDate,
                                    DeptM = e.DeptM,
                                }
                        );
                return query.ToArray();
            }
        }

        public int GetEmployeeCountIndex(ManagerListItem model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx

                        .Employees
                        .Where(e => e.ManagerId == model.ManagerId
                         );
                return query.Count();
            }
        }


        public int GetEmployeeCount(ManagerDetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx

                        .Employees
                        .Where(e => e.ManagerId == model.ManagerId
                         );
                return query.Count();
            }
        }

        public ManagerDetail GetManagerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Managers
                        .Single(e => e.ManagerId == id && e.ManagerOwnerId == _userId);
                return
                    new ManagerDetail
                    {
                        ManagerId = entity.ManagerId,
                        ManagerFirstName = entity.ManagerFirstName,
                        ManagerLastName = entity.ManagerLastName,
                        HiredDate = entity.HiredDate,
                        DeptM = entity.DeptM,
                    };
            }
        }

        public IEnumerable<ManagerDetail> GetManagersByDept(DepartmentM dept)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Managers
                        .Where(e => e.DeptM == dept)
                        .Select(e => new ManagerDetail
                        {
                            ManagerId = e.ManagerId,
                            ManagerFirstName = e.ManagerFirstName,
                            ManagerLastName = e.ManagerLastName,
                            HiredDate = e.HiredDate,
                            DeptM = e.DeptM,
                        });
                return query.ToArray();
            }
        }

        public bool UpdateManager(ManagerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Managers
                        .Single(e => e.ManagerId == model.ManagerId && e.ManagerOwnerId == _userId);

                entity.ManagerFirstName = model.ManagerFirstName;
                entity.ManagerLastName = model.ManagerLastName;
                entity.HiredDate = model.HiredDate;
                entity.DeptM = model.DeptM;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteManager(int managerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Managers
                        .Single(e => e.ManagerId == managerId && e.ManagerOwnerId == _userId);

                ctx.Managers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
