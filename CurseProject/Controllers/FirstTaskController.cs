using CurseProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurseProject.Controllers;

public class FirstTaskController(ITriangleRepository triangleRepository) : Controller
{
    public IActionResult FirstTask()
    {
        var triangles = triangleRepository.GetAllTriangles();
        return View("FirstTask", new TasksViewModel()
        {
           Triangles = triangles,
        });
    }

    public IActionResult DoFirstTask(Double square)
    {
        var delta = Double.MaxValue;
        var sqare = Double.MaxValue;
        var triangles = triangleRepository.GetAllTriangles();
        var enumerable = triangles.ToList();
        using (var triangleList = enumerable.GetEnumerator())
        {
            while (triangleList.MoveNext())
            {
                if (Math.Abs(triangleList.Current.Square - square) <= delta)
                {
                    delta = Math.Abs(triangleList.Current.Square - square);
                    sqare = triangleList.Current.Square;
                }
            }
        }
        
        ICollection<Triangle> test = new List<Triangle>();
        using (var trSet = enumerable.GetEnumerator())
        {
            while (trSet.MoveNext())
            {
                if (Math.Abs(sqare - trSet.Current.Square) < 0.0000003)
                {
                    test.Add(new Triangle()
                    {
                        name = trSet.Current.name,
                        A = trSet.Current.A,
                        B = trSet.Current.B,
                        C = trSet.Current.C,
                        Square = trSet.Current.Square
                    });
                }
            }

            return View("FirstTask", new TasksViewModel()
            {
                Square = square,
                Triangles = test
            });
        }
    }
    
    
}