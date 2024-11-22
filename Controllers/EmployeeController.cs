using EmployeeManagementMVC.Data;
using EmployeeManagementMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDAL dAL;

        public EmployeeController(EmployeeDAL dAL)
        {
            this.dAL = dAL;
        }
        public IActionResult GetEmployees()
        {
            List<Employee> employees = dAL.GetEmployees();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                dAL.AddEmployee(employee);
                return RedirectToAction("GetEmployees");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Employee employee = dAL.GetEmployee(id);
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            Employee employee = dAL.GetEmployee(id);
            return View(employee); 
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                dAL.UpdateEmployee(employee);
                return RedirectToAction("GetEmployees");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee employee = dAL.GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee emp)
        {
            try
            {
                dAL.DeleteEmployee(emp.id);
                return RedirectToAction("GetEmployees");
            }
            catch
            {
                return View();
            }
            
        }
    }
}
