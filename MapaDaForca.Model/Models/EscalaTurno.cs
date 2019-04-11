using System;

namespace MapaDaForca.Model
{
    public class EscalaTurno
    {
        public Guid Id { get; set; }
        public int Turno { get; set; }
        public DateTime DtEscalaTurno { get; set; }
        public bool PeriodoDiurno { get; set; }
    }
}