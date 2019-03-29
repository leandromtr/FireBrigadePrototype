using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaDaForca.Model
{
    public class QuartelViaturaCondicao
    {
        public Guid Id { get; set; }
        public Guid QuartelViaturaId { get; set; }
        public Guid ViaturaId { get; set; }

        [NotMapped]
        public QuartelViatura QuartelViatura { get; set; }
        [NotMapped]
        public IEnumerable<QuartelViatura> QuartelViaturas { get; set; }
        [NotMapped]
        public Viatura Viatura { get; set; }
        [NotMapped]
        public IEnumerable<Viatura> Viaturas { get; set; }
    }



}
