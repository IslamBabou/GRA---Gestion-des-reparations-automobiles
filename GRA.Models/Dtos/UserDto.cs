using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRA.Models.Dtos
{
    public class UserDto
    {
         public int Id { get; set; }
         public int IdRole { get; set; }
         public string LastName { get; set; }
         public string FirstName { get; set; }
         public string Email { get; set; }
         public string Password { get; set; }
         public DateTime? BirthDay { get; set; }
         public string Phone { get; set; }
         public DateTime CreationDate { get; }
         public DateTime? LastLogin { get; set; }
         public bool IsDesactived { get; set; }
    }
}
