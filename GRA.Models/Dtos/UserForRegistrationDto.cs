using System.ComponentModel.DataAnnotations;

namespace GRA.Models.Dtos
{
    public class UserForRegistrationDto
    {
        public int? Id { get; set; }
        public int IdRole { get; set; } = 3;

        [Required(ErrorMessage = "Le nom est requis")]
        [MinLength(2, ErrorMessage = "Le nom doit contenir au minimmum {0} caractères")]
        [MaxLength(50, ErrorMessage = "Le nom doit contenir au maximum {0} caractères")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Le prénom est requis")]
        [MinLength(2, ErrorMessage = "Le prénom doit contenir au minimmum {0} caractères")]
        [MaxLength(50, ErrorMessage = "Le prénom doit contenir au maximum {0} caractères")]
        public string FirstName { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Le champ Email n'est pas une adresse électronique valide")]
        [Required(ErrorMessage = "L'email est requis")]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Le mot de passe est requis")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
         ErrorMessage = "Le mot de passe doit contenir au moins une lettre minuscule, une lettre majuscule, un chiffre, un caractère spécial et au moins 8 caractères.")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Le mot de passe de confirmation est requis")]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "La date de naissance est requise")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Range(typeof(DateTime), "1/1/1990", "12/31/2099", ParseLimitsInInvariantCulture = true, ErrorMessage = "La date de naissance doit être comprise entre {1} et {2}")]
        public DateTime? BirthDay { get; set; }

        [Phone]
        public string Phone { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool IsDeactivated { get; set; }
    }
}