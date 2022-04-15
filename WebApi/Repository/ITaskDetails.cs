using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repository
{
    public interface ITaskDetails
    {
        Task<List<TaskDetail>> GetAllTaskAsync();
        TaskDetail AddTaskDetail(TaskDetail taskDetail);
        void UpdateTask(TaskDetail taskDetail);
        void DeleteTask(int Id);
        TaskDetail GetTask(int Id);
    }
}
