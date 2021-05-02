using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TakeAction.Data.Employee;

namespace TakeAction.Models.Employee
{
    public class EmployeeDetailTwo
    {
        [Display(Name = "Employee ID")]
        public int? EmployeeId { get; set; }

        [Display(Name = "First Name")]
        public string EmployeeFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string EmployeeLastName { get; set; }

        [Display(Name = "Employee Name")]
        public string EmployeeFullName
        {
            get
            {
                var fullName = $"{EmployeeFirstName} {EmployeeLastName}";
                return fullName;
            }
        }

        [Display(Name = "Manager ID")]
        public int? ManagerId { get; set; }

        [Display(Name = "First Name")]
        public string ManagerFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string ManagerLastName { get; set; }

        [Display(Name = "Employee Name")]
        public string ManagerFullName
        {
            get
            {
                var fullName = $"{ManagerFirstName} {ManagerLastName}";
                return fullName;
            }
        }

        [Required]
        [Display(Name = "Hired Date")]
        public DateTimeOffset? HiredDate { get; set; }

        [Display(Name = "Department")]
        public Department Dept { get; set; }
    }
}

