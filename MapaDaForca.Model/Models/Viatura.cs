using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaDaForca.Model
{
    public class Viatura
    {
        public Guid Id { get; set; }
        public Guid ViaturaTipoId { get; set; }
        public string CodigoRSB { get; set; }
        public bool Operacional { get; set; }
        public string Matricula { get; set; }

        [NotMapped]
        public ViaturaTipo ViaturaTipo { get; set; }
        [NotMapped]
        public IEnumerable<ViaturaTipo> ViaturaTipos { get; set; }
    }



}
