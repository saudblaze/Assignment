using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class TaskDetail
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskCode { get; set; }
        public DateTime TaskCreatedDate { get; set; }
    }
}
