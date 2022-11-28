using Task3.Models;

namespace Task3.Services;

public interface IUserService
{
    public void CreateUser(User user);
    public User GetUser(string name);
}