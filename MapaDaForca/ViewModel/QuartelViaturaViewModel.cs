using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.ViewModel
{
    public class QuartelViaturaViewModel
    {

        public Guid QuartelId { get; set; }
        public List<QuartelViatura> QuartelViaturas { get; set; }
        public List<Viatura> Viaturas { get; set; }

    }
}
