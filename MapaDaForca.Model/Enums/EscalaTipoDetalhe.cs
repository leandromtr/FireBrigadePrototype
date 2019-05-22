using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MapaDaForca.Model.Enums
{
    public enum EscalaTipoDetalhe
    {
        [Display(Name = "Disponível para o Serviço")]
        Disponivel = 1,
        [Display(Name = "Indisponível para o Serviço")]
        Indisponivel = 2,
        [Display(Name = "Férias")]
        Ferias = 3
    }
}
