using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeAction.Models.Task
{
    public class TaskDetail
    {
        [Display(Name = "Task Id")]
        public int TaskId { get; set; }

        [Display(Name = "Task Name")]
        public string TaskName { get; set; }

        [Display(Name = "Task Summary")]
        public string TaskSummary { get; set; }

        [Display(Name= "Due Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset DueDate { get; set; }

        [Display(Name = "Flagged")]
        public bool Flagged { get; set; }

        [Display(Name = "Completed")]
        public bool Completed { get; set; }
    }
}
