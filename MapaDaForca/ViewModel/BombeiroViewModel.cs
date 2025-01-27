using MapaDaForca.Model;
using System.Collections.Generic;

namespace MapaDaForca.ViewModel
{
    public class BombeiroViewModel
    {
        public Bombeiro Bombeiro { get; set; }

        public List<BombeiroFuncao> BombeiroFuncoes { get; set; }

        public BombeiroFuncaoViewModel BombeiroFuncaoViewModel { get; set; }
    }
}
