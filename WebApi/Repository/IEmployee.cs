using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repository
{
  public  interface IEmployee
    {
        Task<List<Employee>> GetAllEmployeeAsync();
        Employee AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int Id);
        Employee GetEmployee(int Id);
    }
}
