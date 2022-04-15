using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskDetailsController : ControllerBase
    {
        private readonly ITaskDetails _taskDetails;

        public TaskDetailsController(ITaskDetails taskDetails)
        {
            _taskDetails = taskDetails;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDetail>>> GetAllTaskAsync()
        {
            var result = await _taskDetails.GetAllTaskAsync();
            return result;
        }
        
        [HttpPost]
        // [Route("[action]")]
        public IActionResult Add(TaskDetail taskDetail)
        {
            _taskDetails.AddTaskDetail(taskDetail);
            return Ok();
        }

       
        [HttpPut]
       //public void Put(int id, [FromBody] string value)
        public IActionResult Put(TaskDetail taskDetail)
        {
            _taskDetails.UpdateTask(taskDetail);
            return Ok();
        }

        [HttpDelete("{id}")]
       // [HttpDelete]
        public IActionResult Delete(int id)
        {
            var existingEmployee = _taskDetails.GetTask(id);
            if (existingEmployee != null)
            {
                _taskDetails.DeleteTask(existingEmployee.TaskId);
                return Ok();
            }
            return NotFound($"Employee Not Found with ID : {existingEmployee.TaskId}");
        }
        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var existingEmployee = _taskDetails.GetTask(id);
            if (existingEmployee != null)
            {
                //_employee.DeleteEmployee(existingEmployee.EmpId);
                return Ok(existingEmployee);
            }
            return NotFound($"Employee Not Found with ID : {existingEmployee.TaskId}");
        }
    }
}
