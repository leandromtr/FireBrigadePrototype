using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaDaForca.Model
{
    public class Quartel
    {
        public Guid Id { get; set; }

        [Display(Name = "Companhia")]
        public Guid CompanhiaId { get; set; }

        [Display(Name = "Quartel")]
        public string Nome { get; set; }

        [Display(Name = "Contingente p/ Portaria")]
        public bool Portao { get; set; }

        [NotMapped]
        public Companhia Companhia { get; set; }
        [NotMapped]
        public IEnumerable<Companhia> Companhias { get; set; }
    }



}
