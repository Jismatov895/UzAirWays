using System.Numerics;
using UzAirWays.Domain.Entities;

namespace UzAirWays.DataAccess.Repositories.Users;

public class UserRepository : IUserRepository
{
    private AppDbContext context;
    public UserRepository(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<User> InsertAsync(User user)
    {
        return (await context.Users.AddAsync(user)).Entity;
    }

    public async Task<User> UpdateAsync(User user)
    {
        context.Users.Update(user);
        return await Task.FromResult(user);
    }

    public async Task<User> DeleteAsync(User user)
    {
        user.IsDeleted = true;
        context.Users.Update(user);
        return await Task.FromResult(user);
    }

    public async Task<User> SelectAsync(long id)
    {
        return await context.Users.FindAsync(id);
    }
    public async Task<IEnumerable<User>> SelectAllAsEnumerableAsync()
    {
        return await Task.FromResult(context.Users.Where(user => !user.IsDeleted));
    }

    public async Task<IQueryable<User>> SelectAllAsQuerableAsync()
    {
        return await Task.FromResult(context.Users.AsQueryable().Where(user => !user.IsDeleted));
    }

    public async Task<bool> SaveAsync()
    {
        return (await context.SaveChangesAsync()) > 0;
    }

}
