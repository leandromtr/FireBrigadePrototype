using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaDaForca.Model
{
    public class Viatura
    {
        public Guid Id { get; set; }

        [Display(Name = "Tipo da Viatura")]
        public Guid ViaturaTipoId { get; set; }

        [Display(Name = "Códiggo RSB")]
        public string CodigoRSB { get; set; }

        [Display(Name = "Operacional?")]
        public bool Operacional { get; set; }

        [Display(Name = "Matrícula")]
        public string Matricula { get; set; }

        [NotMapped]
        public ViaturaTipo ViaturaTipo { get; set; }
        [NotMapped]
        public IEnumerable<ViaturaTipo> ViaturaTipos { get; set; }
    }



}
