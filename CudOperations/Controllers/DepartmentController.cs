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
    // Edit action Get
    public IActionResult Edit(int id)
    {
        var department = _departmentRepository.GetOne(d => d.Id == id);
        if(department == null)
        {
            return NotFound();
        }
        return View(department);
    }
    // Edit action Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Department department)
    {
        if (ModelState.IsValid)
        {
            _departmentRepository.Update(department);
            _departmentRepository.Save();
            return RedirectToAction("Index");
        }
        return View(department);
    }
    // Delete action Get
    public IActionResult Delete(int id)
    {
        var department = _departmentRepository.GetOne(d => d.Id == id);
        if (department == null)
        {
            return NotFound();
        }
        return View(department);
    }
    // Delete action Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(Department department)
    {
        _departmentRepository.Remove(department);
        _departmentRepository.Save();
        return RedirectToAction("Index");
    }
}