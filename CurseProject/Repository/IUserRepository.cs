namespace CurseProject.Models;

public interface IUserRepository
{
    User GetById(long id);
    User GetByEmail(string email);
    void CreateUser(User user);
    void UpdateRole(long id);
    bool UserExists(long id);
}