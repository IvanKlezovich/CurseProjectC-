using CurseProject.Models;

namespace CurseProject.Service;

public interface IAuthService
{
    Task SignInWithDefaultPrincipalAsync(User user, string authenticationScheme);
    Task SignInWithDefaultPrincipalAsync(LoginUser loginUserViewModel, string authenticationScheme);
    Task SignOutAsync(string authenticationScheme);
    bool VerifyUserLogin(string email,string userPassword);
}