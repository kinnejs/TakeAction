using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeAction.Data
{
    public class Assignment
    {
        [Key]
        [Display(Name ="Assignment Id")]
        public int? AssignmentId { get; set; }

        [Required]
        public Guid AssignmentOwnerId { get; set; }

        [ForeignKey(nameof(Employ))]
        [Display(Name ="Employee Id")]
        public int? EmployeeId { get; set; }
        public virtual Employee Employ { get; set; }

        [Display(Name = "Employee Name")]
        public string EmployeeFullName { get; set; }

        [ForeignKey(nameof(Man))]
        [Display(Name = "Manager Id")]
        public int? ManagerId { get; set; }
        public virtual Manager Man { get; set; }

        [ForeignKey(nameof(Task))]
        [Display(Name ="Task Id")]
        public int? TaskId { get; set; }
        public virtual Taskl Task { get; set; }

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

        [Display(Name =  "Assigner Name")]
        public string AssignerFullName
        {
            get
            {
                var fullName = $"{AssignerFirstName} {AssignerLastName}";
                return fullName;
            }
        }

        [Required]
        [Display(Name = "Department")]
        public AssignmentDepartment DeptA { get; set; }
        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name = "Assigned Date")]
        public DateTimeOffset? AssignedDate { get; set; }

        public enum AssignmentDepartment
        {
            Finance = 1, Marketing = 2, IT = 3, HR = 4, Management = 5, Other = 6,
        }
    }
}
