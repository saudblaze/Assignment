using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Models
{
    public class DbContext1:DbContext
    {

        public DbContext1(DbContextOptions<DbContext1> options) : base(options)
        {

        }
       


        public  DbSet<Employee> Employees { get; set; }
        public  DbSet<TaskDetail> TaskDetails { get; set; }
        public  DbSet<AssignTask> AssignTasks { get; set; }


    }
}
