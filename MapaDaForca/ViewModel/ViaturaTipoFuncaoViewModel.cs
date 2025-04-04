﻿using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.ViewModel
{
    public class ViaturaTipoFuncaoViewModel
    {

        public Guid ViaturaTipoId { get; set; }
        public List<ViaturaTipoFuncao> ViaturaTipoFuncoes { get; set; }
        public List<ViaturaTipo> ViaturaTipos { get; set; }
        public List<Funcao> Funcoes { get; set; }

    }
}
