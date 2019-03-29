using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaDaForca.Model
{
    public class TipoViaturaFuncao
    {
        public Guid Id { get; set; }
        public Guid TipoViaturaId { get; set; }
        public Guid FuncaoId { get; set; }
        public int Quantidade { get; set; }

        [NotMapped]
        public TipoViatura TipoViatura { get; set; }
        [NotMapped]
        public IEnumerable<TipoViatura> TipoViaturas { get; set; }
        [NotMapped]
        public Funcao Funcao { get; set; }
        [NotMapped]
        public IEnumerable<Funcao> Funcoes { get; set; }
    }



}
