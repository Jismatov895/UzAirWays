using Microsoft.EntityFrameworkCore;
using UzAirWays.DataAccess.Repositories.Planes;
using UzAirWays.Domain.Entities;

namespace UzAirWays.DataAccess.Repositories.Plans;

public class PlanRepository : IPlanRepository
{
    private AppDbContext context;
    public PlanRepository(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<Plane> InsertAsync(Plane plane)
    {
        return (await context.Planes.AddAsync(plane)).Entity;
    }

    public async Task<Plane> UpdateAsync(Plane plane)
    {
        context.Planes.Update(plane);
        return await Task.FromResult(plane);
    }

    public async Task<Plane> DeleteAsync(Plane plane)
    {
        plane.IsDeleted = true;
        context.Planes.Update(plane);
        return await Task.FromResult(plane);
    }

    public async Task<Plane> SelectAsync(long id)
    {
        return await context.Planes.FindAsync(id);
    }

    public async Task<IEnumerable<Plane>> SelectAllAsEnumerableAsync()
    {
        return await Task.FromResult(context.Planes.Where(plane => !plane.IsDeleted));
    }

    public async Task<IQueryable<Plane>> SelectAllAsQuerableAsync()
    {
        return await Task.FromResult(context.Planes.AsQueryable().Where(plane => !plane.IsDeleted));
    }

    public async Task<bool> SaveAsync()
    {
        return (await context.SaveChangesAsync()) > 0;
    }
}
