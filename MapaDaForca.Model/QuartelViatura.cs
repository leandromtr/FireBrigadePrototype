using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaDaForca.Model
{
    public class QuartelViatura
    {
        public Guid Id { get; set; }
        public Guid IdQuartel { get; set; }
        public Guid IdViatura { get; set; }

        [NotMapped]
        public Quartel Quartel { get; set; }
        [NotMapped]
        public IEnumerable<Quartel> Quarteis { get; set; }
        [NotMapped]
        public Viatura Viatura { get; set; }
        [NotMapped]
        public IEnumerable<Viatura> Viaturas { get; set; }
    }



}
