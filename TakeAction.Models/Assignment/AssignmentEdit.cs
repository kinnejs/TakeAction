using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TakeAction.Data.Assignment;

namespace TakeAction.Models.Assignment
{
    public class AssignmentEdit
    {
        [Display(Name = "Assignment Id")]
        public int? AssignmentId { get; set; }

        [Display(Name = "Employee Id")]
        public int? EmployeeId { get; set; }

        
        [Display(Name = "Employee Name")]
        public string EmployeeFullName { get; set; }

        [Display(Name = "Task Id")]
        public int? TaskId { get; set; }

        
        [Display(Name = "Task Name")]
        public string TaskName { get; set; }

        [Display(Name = "Task Summary")]
        public string TaskSummary { get; set; }

        [Display(Name = "Due Date")]
        public DateTimeOffset? DueDate { get; set; }

        [Required]
        [Display(Name = "Assigner First Name")]
        public string AssignerFirstName { get; set; }

        [Required]
        [Display(Name = "Assigner Last Name")]
        public string AssignerLastName { get; set; }

        [Required]
        [Display(Name = "Assignments's Department")]
        public AssignmentDepartment DeptA { get; set; }

        [Required]
        [Display(Name = "Assigned Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? AssignedDate { get; set; }
    }
}
