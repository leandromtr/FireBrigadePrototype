using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaDaForca.Model
{
    public class Companhia
    {
        public Guid Id { get; set; }
        public Guid BatalhaoId { get; set; }
        public string Nome { get; set; }

        [NotMapped]
        public Batalhao Batalhao { get; set; }
        [NotMapped]
        public IEnumerable<Batalhao> Batalhoes { get; set; }
    }



}
