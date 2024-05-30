using GRA.Models.Dtos;

namespace GRA.App.Services.Contracts
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleDto>?> GetAllVehicles();
        Task<IEnumerable<VehicleDto>?> GetVehicleByCustomerId(int customerId);
        Task<VehicleDto> GetVehicleById(int vehicleId);
        Task<IEnumerable<VehicleDto>?> SearchVehicle(string SearchTerm);
        Task UpdateVehicleFirstVisitById(VehicleDto vehicle);
        Task<int> CreateVehicle(VehicleDto vehicle);
    }
}
