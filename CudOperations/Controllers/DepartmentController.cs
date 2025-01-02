using CudOperations.Interfaces;
using CudOperations.Models;
using Microsoft.AspNetCore.Mvc;

namespace CudOperations.Controllers;

public class DepartmentController : Controller
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentController(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;   
    }
    // GET 
    public IActionResult Index()
    {
        var departments = _departmentRepository.GetAll();
        return View(departments);
    }

    // create action Get
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Department department)
    {
        if (ModelState.IsValid)
        {
            _departmentRepository.Add(department);
            _departmentRepository.Save();   
            return RedirectToAction("Index");
        }
        return View(department);
    }
}