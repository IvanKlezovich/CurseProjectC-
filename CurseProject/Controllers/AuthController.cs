using CurseProject.Models;
using CurseProject.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CurseProject.Controllers;

public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    public IActionResult GetLogin()
    {
        return View("Login");
    }
    
    public async Task<IActionResult> PostLogin(LoginUser loginUserViewModel)
    {
        if (!_authService.VerifyUserLogin(loginUserViewModel.Email,
                loginUserViewModel.Password)) return Unauthorized();
        await _authService.SignInWithDefaultPrincipalAsync(loginUserViewModel,
            CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index","Home");
    }
    
    public IActionResult GetSingIn()
    {
        return View("SingIn");
    }
    
    public async Task<IActionResult> PostSingIn(User user)
    {
        await _authService.SignInWithDefaultPrincipalAsync(user, 
            CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index","Home");
    }
}