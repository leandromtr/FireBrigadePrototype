using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaDaForca.Model
{
    public class TipoEscala
    {
        public Guid Id { get; set; }
        public Guid DetalheTipoId { get; set; }
        public string Descricao { get; set; }

        [NotMapped]
        public DetalheTipo DetalheTipo { get; set; }
        [NotMapped]
        public IEnumerable<DetalheTipo> DetalheTipos { get; set; }
    }



}
