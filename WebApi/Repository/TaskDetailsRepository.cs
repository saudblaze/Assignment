using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repository
{
    public class TaskDetailsRepository: ITaskDetails
    {
        private readonly DbContext1 _DbContext1;

        public TaskDetailsRepository(DbContext1 DbContext1)
        {
            _DbContext1 = DbContext1;
        }

        public async Task<List<TaskDetail>> GetAllTaskAsync()
        {
            var records = await _DbContext1.TaskDetails.Select(x => new TaskDetail()
            {
                TaskId = x.TaskId,
                TaskName = x.TaskName,
                TaskCode = x.TaskCode,
                TaskCreatedDate = x.TaskCreatedDate
            }).ToListAsync();
            return records;
        }

        public TaskDetail AddTaskDetail(TaskDetail taskDetail)
        {
            _DbContext1.TaskDetails.Add(taskDetail);
            _DbContext1.SaveChanges();
            return taskDetail;
        }
        public List<TaskDetail> GetTask()
        {
            return _DbContext1.TaskDetails.ToList();
        }

        public void UpdateTask(TaskDetail taskDetail)
        {

            var oldtask = GetTask(taskDetail.TaskId);
            oldtask.TaskId = taskDetail.TaskId;
            oldtask.TaskCode = taskDetail.TaskCode;
            oldtask.TaskName = taskDetail.TaskName;
            _DbContext1.TaskDetails.Update(oldtask);
            _DbContext1.SaveChanges();
        }

        public void DeleteTask(int Id)
        {
            var employee = _DbContext1.TaskDetails.FirstOrDefault(x => x.TaskId == Id);
            if (employee != null)
            {
                _DbContext1.Remove(employee);
                _DbContext1.SaveChanges();
            }
        }

        public TaskDetail GetTask(int Id)
        {
            return _DbContext1.TaskDetails.FirstOrDefault(x => x.TaskId == Id);
        }
    }
}
