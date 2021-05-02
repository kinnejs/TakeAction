using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TakeAction.Data.Assignment;

namespace TakeAction.Models.Assignment
{
    public class AssignmentListItem
    {
        [Display(Name ="Assignment Id")]
        public int? AssignmentId { get; set; }

        [Display(Name = "Employee Name")]
        public string EmployeeFullName { get; set; }

        [Display(Name = "Manager Name")]
        public string ManagerFullName { get; set; }

        [Display(Name = "Assigner Name")]
        public string AssignerFirstName { get; set; }

        [Display(Name = "Task Name")]
        public string TaskName { get; set; }

        [Display(Name = "Task Summary")]
        public string TaskSummary { get; set; }

        [Display(Name = "Due Date")]
        public DateTimeOffset? DueDate { get; set; }

        [Display(Name ="Assigner Last Name")]
        public string AssignerLastName { get; set; }

        [Display(Name = "Assigner Name")]
        public string AssignerFullName
        {
            get
            {
                var fullName = $"{AssignerFirstName} {AssignerLastName}";
                return fullName;
            }
        }

        [Display(Name ="Assignment Department")]
        public AssignmentDepartment DeptA { get; set; }

        [Display(Name ="Assigned Date")]
        public DateTimeOffset? AssignedDate { get; set; }
    }
}
