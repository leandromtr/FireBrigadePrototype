using MapaDaForca.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MapaDaForca.Model
{
    public class EscalaTurno
    {
        public Guid Id { get; set; }

        [Display(Name = "Turno")]
        public Turno Turno { get; set; }

        [Display(Name = "Data da Escala")]
        public DateTime DtEscalaTurno { get; set; }

        [Display(Name = "Período Diúrno")]
        public bool PeriodoDiurno { get; set; }
    }
}