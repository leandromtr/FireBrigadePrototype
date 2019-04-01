using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaDaForca.Model
{
    public class ViaturaTipoFuncao
    {
        public Guid Id { get; set; }
        public Guid ViaturaTipoId { get; set; }
        public Guid FuncaoId { get; set; }
        public int Quantidade { get; set; }

        [NotMapped]
        public ViaturaTipo ViaturaTipo { get; set; }
        [NotMapped]
        public IEnumerable<ViaturaTipo> ViaturaTipos { get; set; }
        [NotMapped]
        public Funcao Funcao { get; set; }
        [NotMapped]
        public IEnumerable<Funcao> Funcoes { get; set; }
    }



}
