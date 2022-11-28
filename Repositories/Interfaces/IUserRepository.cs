using Task3.Models;

namespace Task3.Repositories;

public interface IUserRepository
{
    public void CreateUser(User user);

    public User GetUser(string name);
}