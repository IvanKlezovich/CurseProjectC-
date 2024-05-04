using System.ComponentModel.DataAnnotations;

namespace CurseProject.Models;

public class User
{
    public long Id { get; set; }
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [MinLength(4)]
    public string Password { get; set; } = string.Empty;
    public Role Role { get; set; } = Role.User;
}