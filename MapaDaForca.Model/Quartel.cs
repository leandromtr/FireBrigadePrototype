using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaDaForca.Model
{
    public class Quartel
    {
        public Guid Id { get; set; }
        public Guid IdCompanhia { get; set; }
        public string Nome { get; set; }
        public bool Portao { get; set; }


        [NotMapped]
        public Companhia Companhia { get; set; }
        [NotMapped]
        public IEnumerable<Companhia> Companhias { get; set; }
    }



}
