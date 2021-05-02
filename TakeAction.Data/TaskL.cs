using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeAction.Data
{
    public class Taskl
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        public Guid TaskOwnerId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "The name needs to be at least 3 characters long")]
        [MaxLength(50, ErrorMessage = "The name is too long")]
        [Display(Name = "Task")]
        public string TaskName { get; set; }

        [Required]
        [MaxLength(750, ErrorMessage = "You have entered too many charcters")]
        [Display(Name = "Summary")]
        public string TaskSummary { get; set; }

        
        public string ManagerFullName { get; set; }

        [Required]
        public DateTimeOffset? DueDate { get; set; }

        public bool Flagged { get; set; }

        public bool Completed { get; set; }


    }
}
