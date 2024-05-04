using CurseProject.Context;

namespace CurseProject.Models;

public class UserRepository : IUserRepository
{
    private readonly PostgresDbContext _dbContext;

    public UserRepository(PostgresDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public User GetById(long id)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Id == id);
    }

    public User GetByEmail(string email)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Email == email);
    }

    public void CreateUser(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public void UpdateRole(long id)
    {
        var user = GetById(id);

        if (user.Role is Role.User)
        {
            user.Role = Role.Admin;
        }

        _dbContext.SaveChanges();
    }

    public bool UserExists(long id)
    {
        return GetById(id) is not null;
    }
}