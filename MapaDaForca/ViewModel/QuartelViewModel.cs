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
        
        public QuartelViaturaViewModel QuartelViaturaViewModel { get; set; }

        public IEnumerable<QuantidadeFuncaoViewModel> QuantidadeFuncoesViewModel { get; set; }

        public IEnumerable<Viatura> Viaturas { get; set; }    
        
        public IEnumerable<Bombeiro> Bombeiros { get; set; }        
    }
}
