using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaDaForca.Model
{
    public class Escala
    {
        public Guid Id { get; set; }

        [Display(Name = "Bombeiro")]
        public Guid BombeiroId { get; set; }

        [Display(Name = "Função")]
        public Guid FuncaoId { get; set; }

        [Display(Name = "Quartel")]
        public Guid QuartelId { get; set; }

        [Display(Name = "Tipo da Ausência")]
        public Guid EscalaTipoId { get; set; }

        [Display(Name = "Data")]
        public DateTime DtEscala { get; set; }

        [Display(Name = "Período Diurno")]
        public bool PeriodoDiurno { get; set; }

        [Display(Name = "Prioridade Férias")]
        public int PrioridadeFerias { get; set; }

        [Display(Name = "Aprovado por")]
        public Guid AprovadoPor { get; set; }

        [Display(Name = "Aprovado em")]
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
        public EscalaTipo EscalaTipo { get; set; }
        [NotMapped]
        public IEnumerable<EscalaTipo> EscalaTipos { get; set; }
    }



}
