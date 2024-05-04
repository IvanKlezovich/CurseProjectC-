using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CurseProject.Models;

namespace CurseProject.Controllers;

public class HomeController(ITriangleRepository triangleRepository) : Controller
{
    public IActionResult Index()
    {
        var triangles = triangleRepository.GetAllTriangles();
        return View("Index", triangles);
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult GetLogin()
    {
        return RedirectToAction("GetLogin", "Auth");
    }
    
    public IActionResult GetSingIn()
    {
        return RedirectToAction("GetSingIn", "Auth");
    }
    
    public IActionResult Update(long idTriangle)
    {
        var triangle = triangleRepository.GetTriangleById(idTriangle);
        return View("Add", new AddViewModel()
        {
            Valid = true,
            Triangle = triangle,
            IsUpdate = true
        });
    }
    
    public IActionResult UpdateTriangle(Triangle model)
    {
        if (ModelState.IsValid)
        {
            var triangle = new Triangle
            {
                Id = model.Id,
                name = model.name,
                A = model.A,
                B = model.B,
                C = model.C
            };
            triangle.AreaCalculation();
            if(double.IsNaN(triangle.Square) || triangle.Square < 1)
            {
                return View("Add", new AddViewModel()
                {
                    Triangle = triangle,
                    IsUpdate = true
                });
            }

            triangleRepository.UpdateTriangle(triangle.Id, triangle);

            return RedirectToAction("Index", "Home");
        }

        return View("Add");
    }
    
    public IActionResult Delete(long idTriangle)
    {
        triangleRepository.DeleteTriangle(idTriangle);
        return RedirectToAction("Index");
    }
    
    public IActionResult GetFirstTask()
    {
        return RedirectToAction("FirstTask", "FirstTasks");
    }
    
    public IActionResult GetSecondTask()
    {
        return RedirectToAction("Second Task", "FirstTasks");
    }
    
    public IActionResult GetThirdTask()
    {
        return RedirectToAction("Third Task", "FirstTasks");
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}