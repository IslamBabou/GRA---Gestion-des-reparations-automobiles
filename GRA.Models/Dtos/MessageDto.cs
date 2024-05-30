using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRA.Models.Dtos
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime PublicationDate { get; set; }
        public bool IsRead { get; set; }
        public string Tag { get; set; }
    }
}
