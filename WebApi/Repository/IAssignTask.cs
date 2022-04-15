using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;


namespace WebApi.Repository
{
    public interface IAssignTask
    {
        Task<List<AssignTask>> GetAllAssignTaskAsync();
        //Task<List<AssignTask>> GetAllAssignTaskAsync(int taskid, int userid);
        AssignTask AddAssignTask(AssignTask assignTask);
        void UpdateAssignTask(AssignTask assignTask);
        void DeleteAssignTask(int Id);
         AssignTask GetAssignTask(int Id);
        List<AssignTask> GetAssignTasks(int Id);

        //List<AssignTask> GetAssignTasks(int taskid, int userid);
    }
}
