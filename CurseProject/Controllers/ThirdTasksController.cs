using CurseProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurseProject.Controllers;

public class ThirdTaskController(ITriangleRepository triangleRepository) : Controller
{
    public IActionResult ThirdTask()
    {
        var triangles = triangleRepository.GetAllTriangles();
        return View("ThirdTask", new TasksViewModel()
        {
           Triangles = triangles,
        });
    }

    public IActionResult DoThirdTask(Double radius)
    {
        var triangles = triangleRepository.GetAllTriangles();
        var test = triangles.ToList();
        
        var answer = new List<Triangle>() ?? throw new ArgumentNullException();
        foreach (var item in test)
        {
            var radiusTriangle = (item.A * item.B * item.C) / (4 * item.Square);
            if (radiusTriangle <= radius)
            {
                answer.Add(item);
            }
        }
        
        return View("ThirdTask", new TasksViewModel()
        {
            Triangles = answer
        });
    }
}