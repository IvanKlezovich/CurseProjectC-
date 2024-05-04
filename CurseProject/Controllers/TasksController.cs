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
        return View("FirstTask", new TasksViewModel()
        {
           Triangles = triangles,
           Square = 0
        });
    }

    public IActionResult DoFirstTask(Double square)
    {
        var delta = Double.MaxValue;
        var sqare = Double.MaxValue;
        var triangles = _triangleRepository.GetAllTriangles();
        using (var triangleList = triangles.GetEnumerator())
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
        using (var trSet = triangles.GetEnumerator())
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
    
    public IActionResult SecondTask()
    {
        return View("SecondTask");
    }
    public IActionResult ThirdTask(){
        return View("ThirdTask");
    }
}