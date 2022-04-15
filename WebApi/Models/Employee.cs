using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string EmpName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string EmpAddress { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public int phone { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
