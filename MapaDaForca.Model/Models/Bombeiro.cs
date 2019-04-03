using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MapaDaForca.Model.Enums;
using System.Text;

namespace MapaDaForca.Model
{
    public class Bombeiro
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DtInicio { get; set; }
        public Guid PostoId { get; set; }
        public Guid QuartelId { get; set; }
        public Turno Turno { get; set; }

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
