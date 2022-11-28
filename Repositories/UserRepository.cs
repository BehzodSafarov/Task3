using Task3.Models;

namespace Task3.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    public void CreateUser(User user)
    {
        _context.Users?.Add(user);
        _context.SaveChanges();
    }

    public User GetUser(string name)
    {
        var user = _context.Users?.FirstOrDefault(x => x.Name == name);

        return user!;
    }
}