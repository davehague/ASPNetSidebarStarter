using FmxLite.Model;
using Microsoft.EntityFrameworkCore;

public interface IUserService
{
    Task<List<User>> GetAll();
    Task<User?> Get(int id);
    Task<User> Add(User user);
    Task<User> Update(User user);
    Task<User> Delete(User user);
}

public class UserService : IUserService
{
    private readonly DBContext _context;

    public UserService(DBContext context)
    {
        _context = context;
    }
    public async Task<User?> Get(int id)
        => await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

    public async Task<List<User>> GetAll()
        => await _context.Users.ToListAsync();

    public async Task<User> Add(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> Delete(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }
}
