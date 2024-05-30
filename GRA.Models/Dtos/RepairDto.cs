using GRA.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GRA.Models.Dtos
{
    public class RepairDto
    {
        public int Id {  get; set; }
        public string Code { get; set; }
        public string CustomerFirstName {  get; set; }
        public string CustomerLastName { get; set; }
        public string NumberPlate {  get; set; }
        public string Brand { get; set; }
        public string Model {  get; set; }
        public DateTime DateOpening { get; set; }
        public DateTime DateClosing { get; set; }
        public RepairStatus Status { get; set; }
        public string CreatedBy  {  get; set; }
        public string UpdatedBy { get; set; }
        public decimal  Total { get; set; }
        public decimal  Paid { get; set; }
        public PaymentStatus PaymentStatus  {  get; set; }
    }
}
