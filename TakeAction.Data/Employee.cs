using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeAction.Data
{
    public class Employee
    {
        [Key]
        [Display(Name ="Employee Id")]
        public int? EmployeeId { get; set; }

        [Required]
        public Guid EmployeeOwnerId { get; set; }

        [ForeignKey(nameof(Manager))]
        [Display(Name ="Manager Id")]
        public int? ManagerId { get; set; }
        public virtual Manager Manager { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string EmployeeFirstName { get; set; }

        [Required]
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

        [Required]
        [Display(Name = "Hired Date")]
        public DateTimeOffset? HiredDate { get; set; }

        [Required]
        [Display(Name = "Department")]
        public Department Dept { get; set; }
        public Guid OwnerId { get; set; }


        public enum Department
        {
            Finance = 1,
            Marketing = 2,
            IT = 3,
            HR = 4,
            Management = 5,
            Other = 6,
        }

    }
}
