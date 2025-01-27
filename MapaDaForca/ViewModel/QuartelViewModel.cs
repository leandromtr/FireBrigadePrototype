using MapaDaForca.Model;
using System.Collections.Generic;

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
