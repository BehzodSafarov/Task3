using Task3.Models;
using Task3.Repositories;

namespace Task3.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }
    
    public void CreateUser(User user)
    {
        _repository.CreateUser(user);
    }

    public User GetUser(string name)
    {
        var user = _repository.GetUser(name);

        return user;
    }
}