using GRA.Models.Dtos;

namespace GRA.App.Services.Contracts
{
    public interface IRepairService
    {
        Task<int> CreateRepair(AddOrUpdateRepairDto repair);
        Task<IEnumerable<RepairDto>?> GetAllRepair();
        Task<IEnumerable<RepairDto>?> GetRepairByCustomerId(int customerId);
        Task<AddOrUpdateRepairDto>? GetRepairById(int id);
        Task<IEnumerable<RepairDto>?> GetRepairByNumberPlate(string numberPlate);
    }
}
