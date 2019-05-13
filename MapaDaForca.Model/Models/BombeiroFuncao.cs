using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaDaForca.Model
{
    public class BombeiroFuncao
    {
        public Guid Id { get; set; }

        [Display(Name = "Bombeiro")]
        public Guid BombeiroId { get; set; }

        [Display(Name = "Função")]
        public Guid FuncaoId { get; set; }

        [Display(Name = "Função Principal")]
        public bool FuncaoPrincipal { get; set; }

        [NotMapped]
        public Bombeiro Bombeiro { get; set; }
        [NotMapped]
        public IEnumerable<Bombeiro> Bombeiros { get; set; }
        [NotMapped]
        public Funcao Funcao { get; set; }
        [NotMapped]
        public IEnumerable<Funcao> Funcoes { get; set; }
    }



}
