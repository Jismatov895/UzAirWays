using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzAirWays.Service.DTOs.Planes;

namespace UzAirWays.Service.Services.Planes
{
    internal interface IPlaneService
    {
        Task<PlaneViewModel> CreateAsync(PlaneCreateModel model);
        Task<PlaneViewModel> UpdateAsync(long id, PlaneUpdateModel model);
        Task<bool> DeleteAsync(long id);
        Task<PlaneViewModel> GetByIdAsync(long id);
        Task<IEnumerable<PlaneViewModel>> GetAllAsync();
    }
}
