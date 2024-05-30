


using GRA.Models.Dtos;
using System.Threading.Tasks;

namespace GRA.App.Services.Contracts
{
    public interface IAppointmentService 
    {
        Task AssignMechanic(AppointmentDto appointment);  
        Task<int> CreateAppointment(AppointmentDto appointment);
        Task DeleteAppointment(int id);
        Task<int> CountAppointmentsByMechanicToday(int mechanicId);
        Task<IEnumerable<AppointmentsDetailsDto>?> GetAllAppointmentsDetails();
        Task<IEnumerable<AppointmentDto>?> GetAllAppointments();
        Task<AppointmentsDetailsDto?> GetAppointmentById(int appointmentid);
        Task<IEnumerable<AppointmentsDetailsDto>?> GetTodayAppointments();
        Task<IEnumerable<AppointmentsDetailsDto>?> GetUncompletedAppointments();
        Task UpdateCompletedAppointmentById(int appointmentId);
    }
}
