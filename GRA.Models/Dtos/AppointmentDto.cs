namespace GRA.Models.Dtos
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public DateTime DateAppointment { get; set; }
        public int UserId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
