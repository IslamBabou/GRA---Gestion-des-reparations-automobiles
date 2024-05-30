using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRA.Models.Dtos
{
    public class PaginationDto
    {
        public int Id { get; set; }
        public DateTime EndDate { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string NumberPlate { get; set; }
        public string MechanicFullName { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
    }
}
