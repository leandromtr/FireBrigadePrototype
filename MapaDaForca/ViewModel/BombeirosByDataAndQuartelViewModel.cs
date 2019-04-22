using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapaDaForca.ViewModel
{
    public class EscalaViewModel
    {
        public List<BombeiroViewModel> BombeiroViewModel { get; set; }

        public Quartel quartel { get; set; }

        public string dtEscala { get; set; }
    }
}
