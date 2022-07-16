using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAll();
    Task<User?> GetById(Guid userId);
    Task Create(User user);
    Task Edit(User user);
    Task Remove(Guid userId);
}

public class UserService : IUserService
{
    private readonly AppDbContext _db;

    public UserService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _db.Users.ToListAsync();
    }

    public async Task<User?> GetById(Guid userId)
    {
        return await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task Create(User user)
    {
        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();
    }

    public async Task Edit(User user)
    {
        _db.Users.Update(user);
        await _db.SaveChangesAsync();
    }

    public async Task Remove(Guid userId)
    {
        _db.Users.Remove(new User { Id = userId });
        await _db.SaveChangesAsync();
    }
}
