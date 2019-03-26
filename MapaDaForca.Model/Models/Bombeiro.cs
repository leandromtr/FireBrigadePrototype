using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MapaDaForca.Model
{

    public class Bombeiro
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DtInicio { get; set; }
        public Guid IdPosto { get; set; }
        public Guid IdQuartel { get; set; }
        public int Turno { get; set; }

        [NotMapped]
        public Posto Posto { get; set; }
        [NotMapped]
        public IEnumerable<Posto> Postos { get; set; }
        [NotMapped]
        public Quartel Quartel { get; set; }
        [NotMapped]
        public IEnumerable<Quartel> Quarteis { get; set; }
    }
}
