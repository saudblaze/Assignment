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
    public class AssignTaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
        //public IActionResult AssignTask()
        //{
        //    return View();
        //}
        public async Task<IActionResult> AssignTaskDetails()
        {
            List<AssignTask> reservationList = new List<AssignTask>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:6439/api/AssignTask"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<AssignTask>>(apiResponse);
                }
            }
            List<TaskDetail> taskDetails = new List<TaskDetail>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:6439/api/TaskDetails"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    taskDetails = JsonConvert.DeserializeObject<List<TaskDetail>>(apiResponse);
                }
            }

            List<Employee> userdetails = new List<Employee>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:6439/api/Employee"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userdetails = JsonConvert.DeserializeObject<List<Employee>>(apiResponse);
                }
            }
            ViewBag.tasks = taskDetails;
            ViewBag.users = userdetails;

            return View(reservationList);
        }

        public ActionResult test()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Create(AssignTask model)
        {

            AssignTask obj = new AssignTask();
            using (var httpClient = new HttpClient())
            {
                //obj.At_TaskCreatedDate = DateTime.Now;
                model.At_TaskCreatedDate = DateTime.Now;
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:6439/api/AssignTask/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    obj = JsonConvert.DeserializeObject<AssignTask>(apiResponse);
                }
            }
            return Json(obj);

        }

        [HttpGet]
      //  public async Task<JsonResult> Edit(int EmpId)
        public async Task<JsonResult> Edit(int EmpId)
        {
            AssignTask obj = new AssignTask();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:6439/api/AssignTask/" + EmpId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    obj = JsonConvert.DeserializeObject<AssignTask>(apiResponse);
                }
            }
            
            
            return Json(obj);

        }

        [HttpPost]
        public async Task<JsonResult> Edit(int EmpId, AssignTask model)
        {

            AssignTask obj = new AssignTask();
            using (var httpClient = new HttpClient())
            {
                model.At_TaskCreatedDate = DateTime.Now;
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("http://localhost:6439/api/AssignTask/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    obj = JsonConvert.DeserializeObject<AssignTask>(apiResponse);
                }
            }
            return Json(obj);

        }

        [HttpDelete]
        public async Task<JsonResult> Delete(int EmpId)
        {

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:6439/api/AssignTask/" + EmpId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                }
            }
            return Json("Deleted Successfully");
        }
        
        public async Task<JsonResult> AllUserDetails()
        {
            List<Employee> userdetails = new List<Employee>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:6439/api/Employee"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userdetails = JsonConvert.DeserializeObject<List<Employee>>(apiResponse);
                }
            }
            ViewBag.users1 = userdetails;
            return Json(ViewBag.tasks1);
        }
        public async Task<JsonResult> AllTaskDetails()
        {
            List<TaskDetail> taskDetails = new List<TaskDetail>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:6439/api/TaskDetails"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    taskDetails = JsonConvert.DeserializeObject<List<TaskDetail>>(apiResponse);
                }
            }
            ViewBag.tasks1 = taskDetails;
            return Json(ViewBag.tasks1);
        }
    }
}
