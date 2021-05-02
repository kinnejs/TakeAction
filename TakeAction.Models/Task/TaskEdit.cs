using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeAction.Models.Task
{
    public class TaskEdit
    {
        public int TaskId { get; set; }

        public string TaskName { get; set; }

        public string TaskSummary { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? DueDate { get; set; }

        public bool Flagged { get; set; }

        public bool  Completed { get; set; }
    }
}
