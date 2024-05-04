using Microsoft.AspNetCore.Mvc;
using CurseProject.Models;

namespace CurseProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserRepository _userRepository;
    private readonly ITriangleRepository _triangleRepository;

    public HomeController(ILogger<HomeController> logger, 
        IUserRepository userRepository, ITriangleRepository triangleRepository)
    {
        _triangleRepository = triangleRepository;
        _userRepository = userRepository;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var triangles = _triangleRepository.GetAllTriangles();
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
        var triangle = _triangleRepository.GetTriangleById(idTriangle);
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
    
    public IActionResult Delete(long idTriangle)
    {
        _triangleRepository.DeleteTriangle(idTriangle);
        return RedirectToAction("Index");
    }
    
    public IActionResult GetFirstTask()
    {
        return RedirectToAction("FirstTask", "Tasks");
    }
    
    public IActionResult GetSecondTask()
    {
        return RedirectToAction("Second Task", "Tasks");
    }
    
    public IActionResult GetThirdTask()
    {
        return RedirectToAction("Third Task", "Tasks");
    }
    
    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
}