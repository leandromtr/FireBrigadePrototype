using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaDaForca.Model
{
    public class Escala
    {
        public Guid Id { get; set; }
        public Guid IdBombeiro { get; set; }
        public Guid IdFuncao { get; set; }
        public Guid IdQuartel { get; set; }
        public Guid IdTipoEscala { get; set; }
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
