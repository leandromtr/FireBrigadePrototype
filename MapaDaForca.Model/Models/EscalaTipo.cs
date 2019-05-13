﻿using MapaDaForca.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaDaForca.Model
{
    public class EscalaTipo
    {
        public Guid Id { get; set; }

        [Display(Name = "Detalhe do Tipo")]
        public EscalaTipoDetalhe EscalaTipoDetalhe { get; set; }

        [Display(Name = "Tipo da Ausência")]
        public string Descricao { get; set; }

        //[NotMapped]
        //public EscalaTipoDetalhe EscalaTipoDetalhe { get; set; }
        //[NotMapped]
        //public IEnumerable<EscalaTipoDetalhe> EscalaTipoDetalhes { get; set; }
    }    
}
