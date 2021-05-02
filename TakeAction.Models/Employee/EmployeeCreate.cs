using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TakeAction.Data.Employee;

namespace TakeAction.Models
{
    public class EmployeeCreate
    {
        [Required]
        [Display(Name ="Employee First Name")]
        public string EmployeeFirstName { get; set; }

        [Required]
        [Display(Name ="Employee Last Name")]
        public string EmployeeLastName { get; set; }


        [Display(Name = "Manager Id")]
        public int? ManagerId { get; set; }

        [Required]
        [Display(Name ="Manager Name")]
        public string ManagerFullName { get; set; }

        [Required]
        [Display(Name ="Employee's Department")]
        public Department Dept { get; set; }

        [Required]
        [Display(Name = "Hired Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy", ApplyFormatInEditMode = true)]
        public DateTimeOffset?  HiredDate { get; set; }
    }
}
