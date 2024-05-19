using UzAirWays.DataAccess.Repositories.Planes;
using UzAirWays.Service.DTOs.Planes;
using UzAirWays.Service.Mappers;

namespace UzAirWays.Service.Services.Planes
{
    public class PlaneService : IPlaneService
    {
        private readonly IPlanRepository planRepository;
        public PlaneService(IPlanRepository planRepository)
        {
            this.planRepository = planRepository;
        }

        public async Task<PlaneViewModel> CreateAsync(PlaneCreateModel model)
        {
            var existPlane = (await planRepository.SelectAllAsQuerableAsync()).FirstOrDefault(plane => plane.Number == model.Number && !plane.IsDeleted);
            if (existPlane is not null)
                throw new Exception($"Plane is already exist with this number {model.Number}");

            var plane = Mapper.Map(model);
            plane.CreatedAt = DateTime.UtcNow;
            var createdPlane = await planRepository.InsertAsync(plane);
            await planRepository.SaveAsync();

            return Mapper.Map(createdPlane);
        }

        public async Task<PlaneViewModel> UpdateAsync(long id, PlaneUpdateModel model)
        {
            var existPlane = await planRepository.SelectAsync(id)
                ?? throw new Exception($"Plane is not found with this id: {id}");

            existPlane.Number = model.Number;
            existPlane.BusinessSeats = model.BusinessSeats;
            existPlane.EconomSeats = model.EconomSeats;
            existPlane.UpdatedAt = DateTime.UtcNow;

            var updatedPlane = await planRepository.UpdateAsync(existPlane);
            await planRepository.SaveAsync();

            return Mapper.Map(updatedPlane);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var existPlane = await planRepository.SelectAsync(id)
               ?? throw new Exception($"Plane is not found with this Id {id}");

            existPlane.DeletedAt = DateTime.UtcNow;
            await planRepository.DeleteAsync(existPlane);
            await planRepository.SaveAsync();

            return true;
        }

        public async Task<PlaneViewModel> GetByIdAsync(long id)
        {
            var existPlane = await planRepository.SelectAsync(id)
               ?? throw new Exception($"Plane is not found with this Id {id}");

            return Mapper.Map(existPlane);
        }

        public async Task<IEnumerable<PlaneViewModel>> GetAllAsync()
        {
            var planes = await planRepository.SelectAllAsEnumerableAsync();
            return Mapper.Map(planes);
        }
    }
}
