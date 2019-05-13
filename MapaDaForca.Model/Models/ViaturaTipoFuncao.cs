using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaDaForca.Model
{
    public class ViaturaTipoFuncao
    {
        public Guid Id { get; set; }

        [Display(Name = "Tipo da Viatura")]
        public Guid ViaturaTipoId { get; set; }

        [Display(Name = "Função")]
        public Guid FuncaoId { get; set; }

        [Display(Name = "Quantidade")]
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
