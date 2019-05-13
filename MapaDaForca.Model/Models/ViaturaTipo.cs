using System;
using System.ComponentModel.DataAnnotations;

namespace MapaDaForca.Model
{
    public class ViaturaTipo
    {
        public Guid Id { get; set; }

        [Display(Name = "Sigla")]
        public string Sigla { get; set; }

        [Display(Name = "Tipo da Viatura")]
        public string Descricao { get; set; }
    }
}
