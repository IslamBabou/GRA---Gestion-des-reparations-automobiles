using System.ComponentModel.DataAnnotations;

namespace GRA.Models.Dtos
{
    public class BookAppointmentDto
    {   
        public int Id { get; set; }

        [Required(ErrorMessage = "Le matricule est requis")]
        public string NumberPlate { get; set; }

        [Required(ErrorMessage = "Le nom est requis")]
        [MinLength(2, ErrorMessage = "Le nom doit contenir au minimmum {1} caractères")]
        [MaxLength(50, ErrorMessage = "Le nom doit contenir au maximum {1} caractères")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Le prénom est requis")]
        [MinLength(2, ErrorMessage = "Le prénom doit contenir au minimmum {1} caractères")]
        [MaxLength(50, ErrorMessage = "Le prénom doit contenir au maximum {1} caractères")]
        public string FirstName { get; set; }

        public string CompanyName { get; set; }

        [Required(ErrorMessage = "La date est requise")]
        public DateTime DateAppointment { get; set; }

        public string Nin { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Le champ Email n'est pas une adresse électronique valide")]
        [Required(ErrorMessage = "L'email est requis")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le numéro de téléphone est requis")]
        public string Phone { get; set; }

        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

    


    }
}