using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRA.Models.Enums
{
    public enum RepairStatus
    {
        [Display(Name = "En attente")]
        Pending = 0,
        [Display(Name = "En cours")]
        InProgress = 1,
        [Display(Name = "Terminé")]
        Done = 2,
        [Display(Name = "Annulé")]
        Cancelled = 3 
    }
}
