using MapaDaForca.Model.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaDaForca.Model
{
    public class Bombeiro : IdentityUser
    {
        //public Guid Id { get; set; }

        [Display(Name = "Nº Mecanográfico")]
        public int NumeroMecanografico { get; set; }

        [Display(Name = "Bombeiro")]
        public string Nome { get; set; }

        [Display(Name = "Data de Admissão")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime DtInicio { get; set; }

        [Display(Name = "Posto")]
        public Guid PostoId { get; set; }

        [Display(Name = "Quartel")]
        public Guid QuartelId { get; set; }

        [Display(Name = "Turno")]
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
