using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Repository;
using WebApi.Models;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployee _employee;
        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllMembersAsync()
        {
            var result = await _employee.GetAllEmployeeAsync();
            return result;


        }
        [HttpPost]
        // [Route("[action]")]

        public IActionResult Add(Employee employee)
        {
            _employee.AddEmployee(employee);
            return Ok();
        }

        [HttpPut]
  
        public IActionResult Put(Employee employee)
        {
            _employee.UpdateEmployee(employee);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingEmployee = _employee.GetEmployee(id);
            if (existingEmployee != null)
            {
                _employee.DeleteEmployee(existingEmployee.EmpId);
                return Ok();
            }
            return NotFound($"Employee Not Found with ID : {existingEmployee.EmpId}");
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var existingEmployee = _employee.GetEmployee(id);
            if (existingEmployee != null)
            {
                //_employee.DeleteEmployee(existingEmployee.EmpId);
                return Ok(existingEmployee);
            }
            return NotFound($"Employee Not Found with ID : {existingEmployee.EmpId}");
        }





    }
}
