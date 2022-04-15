using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repository
{
    public class AssignTaskRepository: IAssignTask
    {
        private readonly DbContext1 _DbContext1;
        public AssignTaskRepository(DbContext1 DbContext1)
        {
            _DbContext1 = DbContext1;
        }
        //public async Task<List<AssignTask>> GetAllAssignTaskAsync(int taskid, int userid)
        public async Task<List<AssignTask>> GetAllAssignTaskAsync()
        {
            //var records = await _DbContext1.AssignTasks.Select(x => new AssignTask()
            //{
            //    At_Id = x.At_Id,
            //    At_EmpId = x.At_EmpId,
            //    At_TaskId = x.At_TaskId,
            //    At_TaskCreatedDate = x.At_TaskCreatedDate
            //}).ToListAsync();

            var records = (from a in _DbContext1.AssignTasks
                           join e in _DbContext1.Employees on a.At_EmpId equals e.EmpId
                           join t in _DbContext1.TaskDetails on a.At_TaskId equals t.TaskId
                           //where (a.At_TaskId == taskid || taskid == 0) && (a.At_EmpId == userid || userid == 0)
                           select new AssignTask
                           {
                               At_Id = a.At_Id,
                               At_EmpId = a.At_EmpId,
                               At_TaskId = a.At_TaskId,
                               At_TaskCreatedDate = a.At_TaskCreatedDate,
                               At_Task_Name = t.TaskName,
                               At_Emp_Name = e.EmpName,
                               At_TaskCode=t.TaskCode

                           }
                          ).ToList();

            return records;

           
        }

        public AssignTask AddAssignTask(AssignTask assignTask)
        {
            _DbContext1.AssignTasks.Add(assignTask);
         
            _DbContext1.SaveChanges();
            return assignTask;
        }
        public List<TaskDetail> GetAssignTask()
        {
            return _DbContext1.TaskDetails.ToList();
        }

        public void UpdateAssignTask(AssignTask assignTask)
        {
            _DbContext1.AssignTasks.Update(assignTask);
            _DbContext1.SaveChanges();
        }

        public void DeleteAssignTask(int Id)
        {
            var assigntask = _DbContext1.AssignTasks.FirstOrDefault(x => x.At_Id == Id);
            if (assigntask != null)
            {
                _DbContext1.Remove(assigntask);
                _DbContext1.SaveChanges();
            }
        }

        public AssignTask GetAssignTask(int Id)
        {
            return _DbContext1.AssignTasks.FirstOrDefault(x => x.At_Id == Id);
        }
        public List<AssignTask>  GetAssignTasks(int Id)
        {
            var records = (from a in _DbContext1.AssignTasks
                           join e in _DbContext1.Employees on a.At_EmpId equals e.EmpId
                           join t in _DbContext1.TaskDetails on a.At_TaskId equals t.TaskId
                           where (a.At_Id == Id || a.At_Id == 0)
                           select new AssignTask
                           {
                               At_Id = a.At_Id,
                               At_EmpId = a.At_EmpId,
                               At_TaskId = a.At_TaskId,
                               At_TaskCreatedDate = a.At_TaskCreatedDate,
                               At_Task_Name = t.TaskName,
                               At_Emp_Name = e.EmpName,
                               At_TaskCode=t.TaskCode
                           }).ToList();
                return records;

        }
        //public List<AssignTask> GetAssignTasks(int taskid,int userid)
        //{
        //    var data = _DbContext1.Employees.Where(b => b.EmpId == userid).Select(b => b.EmpName).SingleOrDefault();
        //    var data1 = _DbContext1.TaskDetails.Where(b => b.TaskId == taskid).Select(b => b.TaskName).SingleOrDefault();
        //    var records = (from a in _DbContext1.AssignTasks
        //                  join e in _DbContext1.Employees on a.At_EmpId equals e.EmpId
        //                  join t in _DbContext1.TaskDetails on a.At_TaskId equals t.TaskId
        //                  where (a.At_TaskId == taskid || taskid == 0) && (a.At_EmpId == userid || userid == 0)
        //                  select new AssignTask
        //                  {   At_Id=a.At_Id,
        //                      At_EmpId=a.At_EmpId,
        //                      At_TaskId=a.At_TaskId,
        //                      At_TaskCreatedDate=a.At_TaskCreatedDate,
        //                      At_Task_Name=t.TaskName,
        //                      At_Emp_Name=e.EmpName
        //                  }
        //                  ).ToList();
        //    return records;
        //}
    }
}
