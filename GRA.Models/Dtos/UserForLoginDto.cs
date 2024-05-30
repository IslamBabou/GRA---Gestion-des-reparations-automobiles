using System.ComponentModel.DataAnnotations;

namespace GRA.Models.Dtos
{
    public class UserForLoginDto
    {
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Le champ Email n'est pas une adresse électronique valide")]
        [Required(ErrorMessage = "L'email est requis")]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Le mot de passe est requis")]
        public string? Password { get; set; }
    }
}