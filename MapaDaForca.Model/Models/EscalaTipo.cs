using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaDaForca.Model
{
    public class EscalaTipo
    {
        public Guid Id { get; set; }
        public Guid EscalaTipoDetalheId { get; set; }
        public string Descricao { get; set; }

        [NotMapped]
        public EscalaTipoDetalhe EscalaTipoDetalhe { get; set; }
        [NotMapped]
        public IEnumerable<EscalaTipoDetalhe> EscalaTipoDetalhes { get; set; }
    }



}
