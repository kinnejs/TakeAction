using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TakeAction.Data.Manager;

namespace TakeAction.Models.Manager
{
    public class ManagerDetail
    {
        [Display(Name = "Manager Id")]
        public int? ManagerId { get; set; }

        [Display(Name = "Manager First Name")]
        public string ManagerFirstName { get; set; }

        [Display(Name = "Manager Last Name")]
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
        public DateTimeOffset? HiredDate { get; set; }

        [Display(Name = "# of Subordinates")]
        public int Subordinates { get; set; }

        [Display(Name = "Manager Department")]
        public DepartmentM DeptM { get; set; }
    }
}
