using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class TaskDetail
    {
        [Key]
        public int TaskId { get; set; }
        [Required(ErrorMessage = "TaskName is required")]
        public string TaskName { get; set; }
        [Required(ErrorMessage ="TaskCode is required")]
        public string TaskCode { get; set; }
        public DateTime TaskCreatedDate { get; set; }
    }
}
