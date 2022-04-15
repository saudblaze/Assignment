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
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> EmployeeDetails()
        {
            List<Employee> reservationList = new List<Employee>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:6439/api/Employee"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<Employee>>(apiResponse);
                }
            }
            return View(reservationList);
            
        }



        [HttpPost]
        public async Task<JsonResult> Create(Employee model)
        {

            Employee obj = new Employee();
            using (var httpClient = new HttpClient())
            {
                //obj.CreatedDate = DateTime.Now;
                model.CreatedDate = DateTime.Now;
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:6439/api/Employee/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    obj = JsonConvert.DeserializeObject<Employee>(apiResponse);
                }
            }
            return Json(obj);

        }

        [HttpGet]
        public async Task<JsonResult> Edit(int EmpId)
        {
            Employee obj = new Employee();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:6439/api/Employee/"+EmpId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    obj = JsonConvert.DeserializeObject<Employee>(apiResponse);
                }
            }
              return Json(obj);

        }

        [HttpPost]
        public async Task<JsonResult> Edit(int EmpId, Employee model)
        {
            
            Employee obj = new Employee();
            using (var httpClient = new HttpClient())
            {
                model.CreatedDate = DateTime.Now;
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("http://localhost:6439/api/Employee/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    obj = JsonConvert.DeserializeObject<Employee>(apiResponse);
                }
            }
            return Json(obj);

        }

        [HttpDelete]
        public async Task<JsonResult> Delete(int EmpId)
        {
           
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:6439/api/Employee/" + EmpId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    
                }
            }
            return Json("Deleted");

        }
    }
}
