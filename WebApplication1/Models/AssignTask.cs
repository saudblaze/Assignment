using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class AssignTask
    {
        [Key]
        public int At_Id { get; set; }

        public int At_EmpId { get; set; }
        [NotMapped]
        public string At_Emp_Name { get; set; }
        public int At_TaskId { get; set; }
        [NotMapped]
        public string At_Task_Name { get; set; }
        [NotMapped]
        public string At_TaskCode { get; set; }
        public DateTime At_TaskCreatedDate { get; set; }
    }
}
