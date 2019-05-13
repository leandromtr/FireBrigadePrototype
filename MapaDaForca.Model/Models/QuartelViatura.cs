using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaDaForca.Model
{
    public class QuartelViatura
    {
        public Guid Id { get; set; }

        [Display(Name = "Quartel")]
        public Guid QuartelId { get; set; }

        [Display(Name = "Viatura")]
        public Guid ViaturaId { get; set; }

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
