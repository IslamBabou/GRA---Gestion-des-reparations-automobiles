using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRA.Models.Enums
{
    public enum PaymentStatus
    {
        [Display(Name = "Impayé")]
        Unpaid = 0,
        [Display(Name = "Partiellement payé")]
        PartiallyPaid = 1,
        [Display(Name = "Payé")]
        Paid = 2,
    }
}
