using CurseProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurseProject.Controllers;

public class SecondTaskController(ITriangleRepository triangleRepository) : Controller
{
    public IActionResult SecondTask()
    {
        var triangles = triangleRepository.GetAllTriangles();
        return View("SecondTask", new TasksViewModel()
        {
           Triangles = triangles,
        });
    }

    public IActionResult DoSecondTask(Double sumSquares)
    {
        var triangles = triangleRepository.GetAllTriangles();
        var test = triangles.ToList();

        test.Sort((o1, O2) => (int)(o1.Square - O2.Square));
            
        var answer = new List<Triangle>();
        var sumAnswer = 0.0; 
        foreach (var item in test)
        {
            if (sumAnswer + item.Square < sumSquares)
            {
                answer.Add(item);
                sumAnswer += item.Square;
            }
        }

        return View("SecondTask", new TasksViewModel()
        {   
            Square = sumSquares,
            Triangles = answer
        });
    }
}