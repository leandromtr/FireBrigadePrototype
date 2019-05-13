using System;
using System.ComponentModel.DataAnnotations;

namespace MapaDaForca.Model
{
    public class Posto
    {
        public Guid Id { get; set; }

        [Display(Name = "Posto")]
        public string Nome { get; set; }
    }



}
