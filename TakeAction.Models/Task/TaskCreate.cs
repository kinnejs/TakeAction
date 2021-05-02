using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeAction.Models.Task
{
    public class TaskCreate
    {
        [Required]
        [MinLength(3, ErrorMessage = "The name needs to be at least 3 characters long")]
        [MaxLength(50, ErrorMessage = "The name is too long")]
        [Display(Name ="Task")]
        public string TaskName { get; set; }

        [Required]
        [MaxLength(750, ErrorMessage = "You have entered too many charcters")]
        [Display(Name = "Summary")]
        public string TaskSummary { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? DueDate { get; set; }

        public bool Flagged { get; set; }

        public bool Completed { get; set; }


    }
}
