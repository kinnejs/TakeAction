using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAction.Data;
using TakeAction.Models.Task;

namespace TakeAction.Services
{
    public class TaskService
    {
        private readonly Guid _userId;

        public TaskService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTask(TaskCreate model)
        {
            var entity =
                new Taskl()
                {
                    TaskOwnerId = _userId,
                    TaskName = model.TaskName,
                    TaskSummary = model.TaskSummary,
                    DueDate = model.DueDate,
                    Flagged = model.Flagged,
                    Completed = model.Completed,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tasks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TaskListItem> GetTasks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =

                    ctx

                        .Tasks
                        .Where(e => e.TaskOwnerId == _userId)
                        .Select(
                            e =>

                                new TaskListItem
                                {
                                    TaskId = e.TaskId,
                                    TaskName = e.TaskName,
                                    TaskSummary = e.TaskSummary,
                                    DueDate = e.DueDate,
                                    Flagged = e.Flagged,
                                    Completed = e.Completed,
                                }
                        );

                return query.ToArray();
            }
        }

        public TaskDetail GetTaskById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =

                    ctx
                        .Tasks
                        .Single(e => e.TaskId == id && e.TaskOwnerId == _userId);

                return
                    new TaskDetail
                    {
                        TaskId = entity.TaskId,
                        TaskName = entity.TaskName,
                        TaskSummary = entity.TaskSummary,
                        DueDate = (DateTimeOffset)entity.DueDate,
                        Flagged = entity.Flagged,
                        Completed = entity.Completed,

                    };
            }
        }

        public IEnumerable<TaskListItem> GetFlaggedTasks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Tasks
                        .Where(e => e.Flagged == true && e.TaskOwnerId == _userId)
                        .Select(
                        e =>
                            new TaskListItem
                            {
                                TaskId = e.TaskId,
                                TaskName = e.TaskName,
                                TaskSummary = e.TaskSummary,
                                DueDate = (DateTimeOffset)e.DueDate,
                                Flagged = e.Flagged,
                                Completed = e.Completed,
                            }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<TaskListItem> GetUnflaggedTasks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Tasks
                        .Where(e => e.Flagged == false && e.TaskOwnerId == _userId)
                        .Select(
                        e =>
                            new TaskListItem
                            {
                                TaskId = e.TaskId,
                                TaskName = e.TaskName,
                                TaskSummary = e.TaskSummary,
                                DueDate = (DateTimeOffset)e.DueDate,
                                Flagged = e.Flagged,
                                Completed = e.Completed,
                            }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<TaskListItem> GetCompletedTasks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Tasks
                        .Where(e => e.Completed == true && e.TaskOwnerId == _userId)
                        .Select(
                        e =>
                            new TaskListItem
                            {
                                TaskId = e.TaskId,
                                TaskName = e.TaskName,
                                TaskSummary = e.TaskSummary,
                                DueDate = (DateTimeOffset)e.DueDate,
                                Flagged = e.Flagged,
                                Completed = e.Completed,
                            }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<TaskListItem> GetOutstandingTasks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Tasks
                        .Where(e => e.Completed == false && e.TaskOwnerId == _userId)
                        .Select(
                        e =>
                            new TaskListItem
                            {
                                TaskId = e.TaskId,
                                TaskName = e.TaskName,
                                TaskSummary = e.TaskSummary,
                                DueDate = (DateTimeOffset)e.DueDate,
                                Flagged = e.Flagged,
                                Completed = e.Completed,
                            }
                        );
                return query.ToArray();
            }
        }

        public TaskDetail GetTasksByDueDate(DateTimeOffset? dueDate)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =

                    ctx
                        .Tasks
                        .Single(e => e.DueDate == dueDate);

                return
                    new TaskDetail
                    {
                        TaskId = entity.TaskId,
                        TaskName = entity.TaskName,
                        TaskSummary = entity.TaskSummary,
                        DueDate = (DateTimeOffset)entity.DueDate,
                        Flagged = entity.Flagged,
                        Completed = entity.Completed,

                    };
            }
        }

        public bool UpdateTask(TaskEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tasks
                        .Single(e => e.TaskId == model.TaskId && e.TaskOwnerId == _userId);

                entity.TaskName = model.TaskName;
                entity.TaskSummary = model.TaskSummary;
                entity.DueDate = model.DueDate;
                entity.Flagged = model.Flagged;
                entity.Completed = model.Completed;

                return ctx.SaveChanges() == 1;


            }
        }

        public bool DeleteTask(int TaskId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tasks
                        .Single(e => e.TaskId == TaskId && e.TaskOwnerId == _userId);
                var entity2 =
                    ctx
                        .Assignments
                        .Where(e => e.TaskId == TaskId);
                foreach(var item in entity2)
                {
                    item.TaskId = null;
                }

                ctx.Tasks.Remove(entity);
                var assignmentCount = entity2.Count();
                return ctx.SaveChanges() == assignmentCount + 1;
            }
        }


    }
}
