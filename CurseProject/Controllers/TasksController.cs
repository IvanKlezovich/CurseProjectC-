using CurseProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurseProject.Controllers;

public class TasksController : Controller
{

    private readonly ITriangleRepository _triangleRepository;

    public TasksController(ITriangleRepository triangleRepository)
    {
        _triangleRepository = triangleRepository;
    }
    public IActionResult FirstTask()
    {
        var triangles = _triangleRepository.GetAllTriangles();
        return View("FirstTask", triangles);
    }
    public IActionResult SecondTask()
    {
        return View("SecondTask");
    }
    public IActionResult ThirdTask(){
        return View("ThirdTask");
    }
}