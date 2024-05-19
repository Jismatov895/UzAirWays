using UzAirWays.Domain.Entities;

namespace UzAirWays.DataAccess.Repositories.Users;

public interface IUserRepository
{
    Task<User> InsertAsync(User user);
    Task<User> UpdateAsync(User user);
    Task<User> DeleteAsync(User user);
    Task<User> SelectAsync(long id);
    Task<IEnumerable<User>> SelectAllAsEnumerableAsync();
    Task<IQueryable<User>> SelectAllAsQuerableAsync();
    Task<bool> SaveAsync();
}
