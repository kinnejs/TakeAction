using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeAction.Data
{
    public class Manager
    {
        [Key]
        [Display(Name ="Manager Id")]
        public int? ManagerId { get; set; }

        [Required]
        public Guid ManagerOwnerId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string ManagerFirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
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

        public DateTimeOffset? HiredDate { get; set; }

        [Required]
        [Display(Name = "Department")]
        public DepartmentM DeptM { get; set; }
        

        public enum DepartmentM
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
