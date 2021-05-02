using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAction.Data;
using TakeAction.Models.Assignment;
using static TakeAction.Data.Assignment;

namespace TakeAction.Services
{
    public class AssignmentService
    {
        private readonly Guid _userId;

        public AssignmentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAssignment(AssignmentCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var employeeName = ctx.Employees.Find(model.EmployeeId);
                var taskName = ctx.Tasks.Find(model.TaskId);
                var taskSummary = ctx.Tasks.Find(model.TaskId);
                var taskDueDate = ctx.Tasks.Find(model.TaskId);
                var entity =

                    new Assignment()
                    {
                        AssignmentOwnerId = _userId,
                        OwnerId = _userId,
                        EmployeeId = model.EmployeeId,
                        EmployeeFullName = employeeName.EmployeeFullName,
                        TaskId = model.TaskId,
                        TaskName = taskName.TaskName,
                        TaskSummary = taskSummary.TaskSummary,
                        DueDate = taskDueDate.DueDate,
                        AssignerFirstName = model.AssignerFirstName,
                        AssignerLastName = model.AssignerLastName,
                        DeptA = model.DeptA,
                        AssignedDate = DateTimeOffset.Now,
                    };
                ctx.Assignments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AssignmentListItem> GetAssignments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Assignments
                        .Where(e => e.AssignmentOwnerId == _userId)
                        .Select(
                        e =>
                            new AssignmentListItem
                            {
                                AssignmentId = e.AssignmentId,
                                EmployeeFullName = e.EmployeeFullName,
                                TaskName = e.TaskName,
                                TaskSummary = e.TaskSummary,
                                DueDate = e.DueDate,
                                AssignerFirstName = e.AssignerFirstName,
                                AssignerLastName = e.AssignerLastName,
                                DeptA = e.DeptA,
                                AssignedDate = e.AssignedDate,
                            }
                        );
                return query.ToArray();
            }
        }

        public AssignmentDetail GetAssignmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Assignments
                        .Single(e => e.AssignmentId == id && e.AssignmentOwnerId == _userId);

                return
                    new AssignmentDetail
                    {
                        AssignmentId = entity.AssignmentId,
                        EmployeeId = entity.EmployeeId,
                        EmployeeFullName = entity.EmployeeFullName,
                        TaskId = entity.TaskId,
                        TaskName = entity.TaskName, 
                        TaskSummary = entity.TaskSummary,
                        DueDate = entity.DueDate,
                        AssignerFirstName = entity.AssignerFirstName,
                        AssignerLastName = entity.AssignerLastName,
                        DeptA = entity.DeptA,
                        AssignedDate = entity.AssignedDate,
                    };
            }
        }


        public IEnumerable<AssignmentDetailTwo> GetAssignmentsByEmployeeId(int employeeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Assignments
                        .Where(e => e.EmployeeId == employeeId)
                        .Select(e => new AssignmentDetailTwo
                        {
                            AssignmentId = e.AssignmentId,
                            EmployeeId = e.EmployeeId,
                            EmployeeFullName = e.EmployeeFullName,
                            TaskId = e.TaskId,
                            TaskName = e.TaskName,
                            TaskSummary = e.TaskSummary,
                            DueDate = e.DueDate,
                            AssignerFirstName = e.AssignerFirstName,
                            AssignerLastName = e.AssignerLastName,
                            DeptA = e.DeptA,
                            AssignedDate = e.AssignedDate,
                        });
                return query.ToArray();
            }
        }

        public IEnumerable<AssignmentDetailTwo> GetAssignmentsByDueDate(DateTimeOffset? dueDate)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Assignments
                        .Where(e => e.DueDate == dueDate)
                        .Select(e => new AssignmentDetailTwo
                        {
                            AssignmentId = e.AssignmentId,
                            EmployeeId = e.EmployeeId,
                            EmployeeFullName = e.EmployeeFullName,
                            TaskId = e.TaskId,
                            TaskName = e.TaskName,
                            TaskSummary = e.TaskSummary,
                            DueDate = e.DueDate,
                            AssignerFirstName = e.AssignerFirstName,
                            AssignerLastName = e.AssignerLastName,
                            DeptA = e.DeptA,
                            AssignedDate = e.AssignedDate,
                        });
                return query.ToArray();
            }
        }

        public bool UpdateAssignment(AssignmentEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var employeeName = ctx.Employees.Find(model.EmployeeId);
                var taskName = ctx.Tasks.Find(model.TaskId);
                var taskSummary = ctx.Tasks.Find(model.TaskId);
                var taskDueDate = ctx.Tasks.Find(model.TaskId);
                var entity =
                    ctx
                        .Assignments
                        .Single(e => e.AssignmentId == model.AssignmentId && e.AssignmentOwnerId == _userId);
                entity.TaskId = model.TaskId;
                entity.TaskName = taskName.TaskName;
                entity.TaskSummary = taskSummary.TaskSummary;
                entity.DueDate = taskDueDate.DueDate;
                entity.EmployeeId = model.EmployeeId;
                entity.EmployeeFullName = employeeName.EmployeeFullName;
                entity.AssignerFirstName = model.AssignerFirstName;
                entity.AssignerLastName = model.AssignerLastName;
                entity.DeptA = model.DeptA;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAssignment(int assignmentId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Assignments
                        .Single(e => e.AssignmentId == assignmentId && e.AssignmentOwnerId == _userId);

                ctx.Assignments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
