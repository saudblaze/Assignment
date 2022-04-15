using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repository
{
    public class EmployeeRepository: IEmployee
    {
     
      

        public DbContext1 _DbContext1;
        public EmployeeRepository(DbContext1 DbContext1)
        {
            _DbContext1 = DbContext1;
        }

        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            var records =  await _DbContext1.Employees.Select(x=> new Employee()
            {
                EmpId=x.EmpId,
                EmpName=x.EmpName,
                EmpAddress=x.EmpAddress,
                phone=x.phone,
                CreatedDate=x.CreatedDate
            }).ToListAsync();
            return records;
        }
        public Employee AddEmployee(Employee employee)
        {
            _DbContext1.Employees.Add(employee);
            _DbContext1.SaveChanges();
            return employee;
        }
        public List<Employee> GetEmployees()
        {
            return _DbContext1.Employees.ToList();
        }

        public void UpdateEmployee(Employee employee)
        {
            _DbContext1.Employees.Update(employee);
            _DbContext1.SaveChanges();
        }

        public void DeleteEmployee(int Id)
        {
            var employee = _DbContext1.Employees.FirstOrDefault(x => x.EmpId == Id);
            if (employee != null)
            {
                _DbContext1.Remove(employee);
                _DbContext1.SaveChanges();
            }
        }

        public Employee GetEmployee(int Id)
        {
            return _DbContext1.Employees.FirstOrDefault(x => x.EmpId == Id);
        }

    }
}
