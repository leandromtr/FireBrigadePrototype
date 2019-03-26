using System;

namespace MapaDaForca.Model
{
    public class EscalaTurno
    {
        public Guid Id { get; set; }
        public int Turno { get; set; }
        public DateTime Data { get; set; }
        public bool Periodo1 { get; set; }
    }



}
