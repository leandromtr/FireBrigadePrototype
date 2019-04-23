using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MapaDaForca.Model.Enums
{
    public enum Turno
    {
        [Display(Name = "Turno 1")]
        T1 = 1,
        [Display(Name = "Turno 2")]
        T2 = 2,
        [Display(Name = "Turno 3")]
        T3 = 3,
        [Display(Name = "Turno 4")]
        T4 = 4,
    }
}
