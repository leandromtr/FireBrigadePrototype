﻿using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.ViewModel
{
    public class BombeiroFuncaoViewModel
    {
        public Guid BombeiroId { get; set; }
        public List<BombeiroFuncao> BombeiroFuncoes { get; set; }
        public List<Funcao> Funcoes { get; set; }

    }
}
