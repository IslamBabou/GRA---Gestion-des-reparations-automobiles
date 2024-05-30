using GRA.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRA.Models.Dtos
{
    public class AddOrUpdateRepairDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le code est requis")]
        [MaxLength(10, ErrorMessage = "Le code doit contenir au maximum {0} caractères")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Le client est requis")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Le véhicule est requis")]
        public int VehicleId { get; set; }
        [Required(ErrorMessage = "La date d'ouverture est requise")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Range(typeof(DateTime), "1/1/1990", "12/31/2099", ParseLimitsInInvariantCulture = true, ErrorMessage = "La date d'ouverture' doit être comprise entre {1} et {2}")]
        public DateTime DateOpening { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Range(typeof(DateTime), "1/1/1990", "12/31/2099", ParseLimitsInInvariantCulture = true, ErrorMessage = "La date de fermeture doit être comprise entre {1} et {2}")]
        public DateTime? DateClosing { get; set; }
        public RepairStatus Status { get; set; }
        public string CreatedBy {  get; set; }
        public string UpdatedBy { get; set;}
        [DisplayFormat(DataFormatString = "{0:#.##")]
        public decimal Total {  get; set; }
        [DisplayFormat(DataFormatString = "{0:#.##")]
        public decimal Paid { get; set; }
        public PaymentStatus PaymentStatus {  get; set; }
    }
}
