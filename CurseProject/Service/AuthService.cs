using System.Security.Claims;
using CurseProject.Models;
using Microsoft.AspNetCore.Authentication;

namespace CurseProject.Service;

public class AuthService(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
    : IAuthService
{
    public async Task SignInWithDefaultPrincipalAsync(User user, string authenticationScheme)
    {
        if (!userRepository.UserExists(user.Id)){
            userRepository.CreateUser(user);
        }
        var claims = new List<Claim> {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString()) };
        var claimsIdentity = new ClaimsIdentity(claims, authenticationScheme);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        
        await httpContextAccessor.HttpContext.SignInAsync(authenticationScheme, claimsPrincipal);
    }

    public async Task SignInWithDefaultPrincipalAsync(LoginUser loginUserViewModel, string authenticationScheme)
    {
        var user = userRepository.GetByEmail(loginUserViewModel.Email) ?? throw new Exception();
        
        await SignInWithDefaultPrincipalAsync(user, authenticationScheme);
    }

    public async Task SignOutAsync(string authenticationScheme)
    {
        await httpContextAccessor.HttpContext.SignOutAsync(authenticationScheme);
    }

    public bool VerifyUserLogin(string email, string userPassword)
    {
        var user = userRepository.GetByEmail(email) ?? throw new Exception();
        
        return user.Email == email && user.Password == userPassword;
    }
}