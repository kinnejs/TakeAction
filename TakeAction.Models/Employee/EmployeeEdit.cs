using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TakeAction.Data.Employee;

namespace TakeAction.Models
{
    public class EmployeeEdit
    {
        [Display(Name = "Employee Id")]
        public int? EmployeeId { get; set; }

        [Display(Name = "Employee First Name")]
        public string EmployeeFirstName { get; set; }

        [Display(Name = "Employee Last Name")]
        public string EmployeeLastName { get; set; }

        [Display(Name = "Employee Name")]
        public string EmployeeFullName { get; set; }

        [Display(Name = "Manager Id")]
        public int? ManagerId { get; set; }

        [Display(Name = "Manager Name")]
        public string ManagerFullName { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hired Date")]
        public DateTimeOffset? HiredDate { get; set; }

        [Display(Name ="Employee Department")]
        public Department Dept { get; set; }
    }
}
