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

        public TaskDetail GetFlaggedTasks(bool flagged)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =

                    ctx
                        .Tasks
                        .Single(e => e.Flagged == true && e.TaskOwnerId == _userId);

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

        public TaskDetail GetCompletedTasks(bool complete)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =

                    ctx
                        .Tasks
                        .Single(e => e.Completed == true && e.TaskOwnerId == _userId);

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

        public TaskDetail GetOutstandingTasks(bool outstanding)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =

                    ctx
                        .Tasks
                        .Single(e => e.Completed == false && e.TaskOwnerId == _userId);

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

                ctx.Tasks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
