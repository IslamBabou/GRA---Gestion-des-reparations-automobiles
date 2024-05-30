using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRA.Models.Dtos
{
    public class AppointmentsDetailsDto
    {   
        public int AppointmentId { get; set; }
        public int MechanicId {  get; set; }
        public bool IsCompleted { get; set;}
        public int CustomerId { get; set; }
        public string NumberPlate {  get; set; }
        public DateTime DateAppointment { get; set; }
        public string CustomerFirstName {  get; set; }
        public string CustomerLastName { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string MechanicFullName {  get; set; }
    }
}
