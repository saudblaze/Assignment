using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Repository;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignTaskController : ControllerBase
    {
        private readonly IAssignTask _assignTask;

        public AssignTaskController(IAssignTask assignTask)
        {
            _assignTask = assignTask;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignTask>>> GetAllAssignTaskAsync()
        {
            var result = await _assignTask.GetAllAssignTaskAsync();
            //var result = await _assignTask.GetAllAssignTaskAsync(int taskid, int userid);
            return result;
        }

        // GET: api/<AssignTaskController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<AssignTaskController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<AssignTaskController>
        [HttpPost]
        // public void Post([FromBody] string value)
        public IActionResult Add(AssignTask assignTask)
        {
            _assignTask.AddAssignTask(assignTask);
        
            return Ok();
        }

        // PUT api/<AssignTaskController>/5
        //[HttpPut("{id}")]
        [HttpPut]
        //public void Put(int id, [FromBody] string value)
        public IActionResult Put(AssignTask assignTask)
        {
            _assignTask.UpdateAssignTask(assignTask);
            return Ok();
        }

        // DELETE api/<AssignTaskController>/5
         [HttpDelete("{id}")]
        //public void Delete(int id)
       // [HttpDelete]
        public IActionResult Delete(int id)
        {
            var existingEmployee = _assignTask.GetAssignTask(id);
            if (existingEmployee != null)
            {
                _assignTask.DeleteAssignTask(existingEmployee.At_Id);
                return Ok();
            }
            return NotFound($"Employee Not Found with ID : {existingEmployee.At_Id}");
        }
        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            //var existingEmployee = _assignTask.GetAssignTask(id);
            var existingEmployee = _assignTask.GetAssignTask(id);
            if (existingEmployee != null)
            {
                //_employee.DeleteEmployee(existingEmployee.EmpId);
               
            }
            // return NotFound($"Employee Not Found with ID : {existingEmployee.At_Id}");
           // return NotFound("Employee Not Found");
           return Ok(existingEmployee);
        }
        
    }
}
