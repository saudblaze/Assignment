using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TaskDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TaskDetailData()
        {
            List<TaskDetail> reservationList = new List<TaskDetail>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:6439/api/TaskDetails"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<TaskDetail>>(apiResponse);
                }
            }
            return View(reservationList);
        }
        [HttpPost]
        public async Task<JsonResult> Create(TaskDetail model)
        {

            TaskDetail obj = new TaskDetail();
            using (var httpClient = new HttpClient())
            {
                //obj.TaskCreatedDate = DateTime.Now;
                model.TaskCreatedDate = DateTime.Now;
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:6439/api/TaskDetails/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    obj = JsonConvert.DeserializeObject<TaskDetail>(apiResponse);
                }
            }
            return Json(obj);

        }

        [HttpGet]
        public async Task<JsonResult> Edit(int EmpId)
        {
            TaskDetail obj = new TaskDetail();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:6439/api/TaskDetails/" + EmpId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    obj = JsonConvert.DeserializeObject<TaskDetail>(apiResponse);
                }
            }
            return Json(obj);

        }
        [HttpPost]
        public async Task<JsonResult> Edit(int TaskId, TaskDetail model)
        {

            TaskDetail obj = new TaskDetail();
            using (var httpClient = new HttpClient())
            {
                model.TaskCreatedDate = DateTime.Now;
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("http://localhost:6439/api/TaskDetails/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    obj = JsonConvert.DeserializeObject<TaskDetail>(apiResponse);
                }
            }
            return Json(obj);

        }
        [HttpDelete]
        public async Task<JsonResult> Delete(int EmpId)
        {

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:6439/api/TaskDetails/" + EmpId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                }
            }
            return Json("Deleted");

        }
    }
}
