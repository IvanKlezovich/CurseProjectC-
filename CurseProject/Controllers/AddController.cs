using CurseProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurseProject.Controllers;

public class AddController : Controller
{

    private readonly ITriangleRepository _triangleRepository;

    public AddController(ITriangleRepository triangleRepository)
    {
        _triangleRepository = triangleRepository;
    }
    
    public IActionResult AddTriangle()
    {
        return View("Add");
    }
    
    [HttpPost]
    public IActionResult SaveTriangle(Triangle model)
    {
        if (ModelState.IsValid)
        {
            var triangle = new Triangle
            {
                name = model.name,
                a = model.a,
                b = model.b,
                c = model.c
            };

            _triangleRepository.AddTriangle(triangle);

            return RedirectToAction("Index", "Home");
        }

        return View("Add");
    }
    
    public IActionResult Update(long id)
    {
        var triangle = _triangleRepository.GetTriangleById(id);
        return View("Add", triangle);
    }

    public IActionResult UpdateTriangle(Triangle model)
    {
        if (ModelState.IsValid)
        {
            var triangle = new Triangle
            {
                id = model.id,
                name = model.name,
                a = model.a,
                b = model.b,
                c = model.c
            };

            _triangleRepository.UpdateTriangle(triangle.id, triangle);

            return RedirectToAction("Index", "Home");
        }

        return View("Add");
    }
}