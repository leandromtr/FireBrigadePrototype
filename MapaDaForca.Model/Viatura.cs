using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaDaForca.Model
{
    public class Viatura
    {
        public Guid Id { get; set; }
        public Guid IdTipoViatura { get; set; }
        public bool Operacional { get; set; }
        public string Matricula { get; set; }
        public int Ano { get; set; }
        public DateTime DataInicioUso { get; set; }

        [NotMapped]
        public TipoViatura TipoViatura { get; set; }
        [NotMapped]
        public IEnumerable<TipoViatura> TipoViaturas { get; set; }
    }



}
