using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using MuhmadOmarHajHamdo.Models;
using MuhmadOmarHajHamdo.Models.Repositories;

namespace MuhmadOmarHajHamdo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _employeeRepo = new EmployeeRepository();

        // GET: EmployeeController
        public ActionResult Index()
        {
            // Get all employees from a database
            _employeeRepo.GetAllEmployees();
            return View(EmployeeRepository.Employees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            Employee? employee = _employeeRepo.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                _employeeRepo.CreateEmployee(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}