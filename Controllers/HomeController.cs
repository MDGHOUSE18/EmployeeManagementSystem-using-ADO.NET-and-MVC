using EmployeeManagementMVC.Data;
using EmployeeManagementMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeManagementMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeDAL dal;

        public HomeController(EmployeeDAL dAL)
        {
            dal = dAL;
        }

        public IActionResult Index()
        {
            var employees = dal.GetEmployees();
            return View(employees);
        }

        public IActionResult Privacy()
        {
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
