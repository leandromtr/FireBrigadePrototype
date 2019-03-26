using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaDaForca.Model
{
    public class Log
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid IdBatalhao { get; set; }

        [NotMapped]
        public Batalhao Batalhao { get; set; }
        [NotMapped]
        public IEnumerable<Batalhao> Batalhoes { get; set; }
    }



}
