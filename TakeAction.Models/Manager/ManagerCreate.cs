using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TakeAction.Data.Manager;

namespace TakeAction.Models.Manager
{
    public class ManagerCreate
    {
        [Required]
        [Display(Name ="Manager First Name")]
        public string ManagerFirstName { get; set; }

        [Required]
        [Display(Name ="Manager Last Name")]
        public string ManagerLastName { get; set; }

        [Display(Name = "Manager Name")]
        public string ManagerFullName
        {
            get
            {
                var fullName = $"{ManagerFirstName} {ManagerLastName}";
                return fullName;
            }
        }

        [Display(Name = "Hired Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy", ApplyFormatInEditMode = true)]
        public DateTimeOffset? HiredDate { get; set; }

        [Display(Name ="# of Subordinates")]
        public int Subordinates { get; set; }

        [Required]
        [Display(Name ="Manager's Department")]
        public DepartmentM DeptM { get; set; }
    }
}
