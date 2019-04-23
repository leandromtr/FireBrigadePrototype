using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaDaForca.Model
{
    public class BombeiroFuncao
    {
        public Guid Id { get; set; }
        public Guid BombeiroId { get; set; }
        public Guid FuncaoId { get; set; }
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
