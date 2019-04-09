using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapaDaForca.ViewModel
{
    public class QuartelViewModel
    {
        public Quartel Quartel { get; set; }

        //public List<QuartelViatura> QuartelViaturas { get; set; }
        public QuartelViaturaViewModel QuartelViaturaViewModel { get; set; }

        public List<Viatura> Viaturas { get; set; }
        
    }
}
