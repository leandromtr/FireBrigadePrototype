using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MapaDaForca.Model.Enums
{
    public enum Turno
    {
        [Display(Name = "Turno 1")]
        Turno1 = 1,
        [Display(Name = "Turno 2")]
        Turno2 = 2,
        [Display(Name = "Turno 3")]
        Turno3 = 3,
        [Display(Name = "Turno 4")]
        Turno4 = 4,
    }
}
