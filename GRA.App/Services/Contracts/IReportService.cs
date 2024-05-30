using GRA.Models.Dtos;

namespace GRA.App.Services.Contracts
{
    public interface IReportService
    {
        Task ArchiverReport(int reportId);
        Task<IEnumerable<ReportDto>?> GetAllReports();
        Task<ReportDto?> GetReportById(int reportId);
        Task<IEnumerable<ReportDto>?> GetReportByVehicleId(int vehicleId);
        Task<int> GetReportsCount();
        Task<IEnumerable<ReportDto>?> GetReportByCustomerId(int vehicleId);
        Task<int> CreateReport(ReportDto report);
    }
}
