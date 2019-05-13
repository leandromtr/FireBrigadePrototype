using System;
using System.ComponentModel.DataAnnotations;

namespace MapaDaForca.Model
{
    public class Funcao
    {
        public Guid Id { get; set; }

        [Display(Name = "Função")]
        public string Nome { get; set; }
    }
}
