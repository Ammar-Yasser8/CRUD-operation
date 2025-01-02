using CrudOperations.ViewModels;
using CudOperations.Implementaions;
using CudOperations.Interfaces;
using CudOperations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrudOperations.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmpolyeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        public EmployeeController(IEmpolyeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }
        // action Get to display all employees
        public IActionResult Index()
        {
            var employees = _employeeRepository.GetAll(include:"Department");
            return View(employees);
        }
        // action Get to create employee
        public IActionResult Create()
        {
            EmployeeDepartmentVM employeeVM = new EmployeeDepartmentVM()
            {
                DepartmentList = _departmentRepository.GetAll().Select(d => new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                }).ToList()
            };
           
            return View(employeeVM);
        }
        // action Post to create employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeDepartmentVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Add(employeeVM.Employee);
                _employeeRepository.Save();
                return RedirectToAction(nameof(Index));
            }

            // Log validation errors
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }

            // Repopulate Departments
            employeeVM.DepartmentList = _departmentRepository.GetAll().Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            }).ToList();

            return View(employeeVM);
        }

        // action Get to edit employee
        public IActionResult Edit(int id)
        {
            var employee = _employeeRepository.GetOne(e=>e.Id == id , include:"Department");
            if (employee == null)
            {
                return NotFound();
            }
            var employeeVM = new EmployeeDepartmentVM
            {
                Employee = employee,
                DepartmentList = _departmentRepository.GetAll().Select(d => new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                }).ToList()
            };
            return View(employeeVM);

        }
        // action Post to edit employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeDepartmentVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Update(employeeVM.Employee);
                _employeeRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            // Log validation errors
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            // Repopulate Departments
            employeeVM.DepartmentList = _departmentRepository.GetAll().Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            }).ToList();
            return View(employeeVM);
        }
        // action Get to delete employee
        public IActionResult Delete(int id)
        {
            var employee = _employeeRepository.GetOne(e => e.Id == id, include: "Department");
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        // action Post to delete employee
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _employeeRepository.GetOne(e => e.Id == id , include:"Department");
            if (employee == null)
            {
                return NotFound();
            }
            _employeeRepository.Remove(employee);
            _employeeRepository.Save();
            return RedirectToAction(nameof(Index));
        }


    }
}
