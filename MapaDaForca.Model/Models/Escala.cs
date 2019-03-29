using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaDaForca.Model
{
    public class Escala
    {
        public Guid Id { get; set; }
        public Guid BombeiroId { get; set; }
        public Guid FuncaoId { get; set; }
        public Guid QuartelId { get; set; }
        public Guid TipoEscalaId { get; set; }
        public DateTime Data { get; set; }
        public bool Periodo1 { get; set; }
        public int PrioridadeFerias { get; set; }
        public Guid AprovadoPor { get; set; }
        public DateTime AprovadoEm { get; set; }

        [NotMapped]
        public Bombeiro Bombeiro { get; set; }
        [NotMapped]
        public IEnumerable<Bombeiro> Bombeiros { get; set; }
        [NotMapped]
        public Funcao Funcao { get; set; }
        [NotMapped]
        public IEnumerable<Funcao> Funcoes { get; set; }
        [NotMapped]
        public Quartel Quartel { get; set; }
        [NotMapped]
        public IEnumerable<Quartel> Quarteis { get; set; }
        [NotMapped]
        public TipoEscala TipoEscala { get; set; }
        [NotMapped]
        public IEnumerable<TipoEscala> TipoEscalas { get; set; }
    }



}
