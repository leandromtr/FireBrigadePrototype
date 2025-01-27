using MapaDaForca.Model;
using System.Collections.Generic;

namespace MapaDaForca.ViewModel
{
    public class EscalaViewModel
    {
        public List<BombeiroViewModel> BombeiroViewModel { get; set; }

        public Quartel quartel { get; set; }

        public string dtEscala { get; set; }
    }
}
