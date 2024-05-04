using CurseProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurseProject.Controllers;

public class AddController(ITriangleRepository triangleRepository) : Controller
{
    public IActionResult AddTriangle()
    {
        return View("Add", new AddViewModel()
        {
            Triangle = null
        });
    }
    
    [HttpPost]
    public IActionResult SaveTriangle(Triangle model)
    {
        if (ModelState.IsValid)
        {
            var triangle = new Triangle
            {
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
                    Triangle = triangle
                });
            }

            triangleRepository.AddTriangle(triangle);

            return RedirectToAction("Index", "Home");
        }

        return View("Add");
    }
    
}