using MapaDaForca.Model;
using System.Collections.Generic;

namespace MapaDaForca.ViewModel
{
    public class RSBAtualDiarioViewModel
    {
        public Quartel Quartel { get; set; }

        public QuartelViaturaViewModel QuartelViaturaViewModel { get; set; }

        public IEnumerable<QuantidadeFuncaoViewModel> QuantidadeFuncoesDiurnoViewModel { get; set; }
        public IEnumerable<QuantidadeFuncaoViewModel> QuantidadeFuncoesNoturnoViewModel { get; set; }

        public IEnumerable<Viatura> ViaturasDiurno { get; set; }
        public IEnumerable<Viatura> ViaturasNoturno { get; set; }

        public IEnumerable<Bombeiro> BombeirosDiurno { get; set; }
        public IEnumerable<Bombeiro> BombeirosNoturno { get; set; }
    }
}
