using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MapaDaForca.Model
{
    public class Batalhao
    {
        
        public Guid Id { get; set; }

        [Display(Name = "Batalhão")]
        public string Nome { get; set; }
    }
}
